using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Roz.Data;
using Roz.I18N.Utilities;
using Roz.Infrastructure.Services;
using Roz.Mapping;
using Roz.Utilities;
using EditVM = Roz.Infrastructure.Web.Models.EditVM;
using FilterVM = Roz.Infrastructure.Web.Models.FilterVM;
using ServiceResult = Roz.Infrastructure.Web.Services.ServiceResult;

namespace Roz.Infrastructure.Web.Mvc
{
    public class CrudController<TId, TEntity, TEditVM, TListVM, TFilterVM> : Controller
        where TEntity : class, IEntityWithKey<TId>, new()
        where TEditVM : EditVM, new()
        where TListVM : Models.ListVM<TEntity>, new()
        where TFilterVM : FilterVM, new()
    {
        protected string EditView = "Edit";
        protected string CreateView = "Create";
        protected string IndexView = "Index";
        protected int PageSize = 15;

        protected Services.Service<TId, TEntity> _service;
        protected  IMappingProvider _mappingProvider;

        public CrudController(Services.Service<TId, TEntity> service, IMappingProvider mappingProvider):base()
        {
            _service = service;
            _mappingProvider = mappingProvider;
        }

        [HttpGet]
        public virtual ActionResult Index(int page = 1)
        {
            return View(IndexView, ExecuteList(CurrentPage));
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            GetFilter();
            return RedirectToAction("Index", GetRoutesValues());
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            TEditVM viewModel = new TEditVM();
            InitializeEditViewModel(viewModel);
            return View(CreateView, viewModel);
        }

        [HttpPost]
        public virtual ActionResult Create(TEditVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = ExecuteInsert(CreateEntity(viewModel), viewModel);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Messages)
                    {
                        ModelState.AddModelError(item.ResourceKey, LocalizedExtensions.GetText(item.ResourceKey));
                    }
                }
            }

            InitializeEditViewModel(viewModel);
            return View(CreateView, viewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(TId id)
        {
            var entity = _service.Get(id);
            if (entity != null)
            {
                GetFilter();
                var viewModel = CreateViewModel(entity);
                return View(EditView, viewModel);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public virtual ActionResult Edit(TId Id, TEditVM viewModel)
        {
            var entity = _service.Get(Id);
            if (ModelState.IsValid)
            {
                if (entity != null)
                {
                    FromViewModelToEntity(viewModel, entity);
                    var result = ExecuteUpdate(entity, viewModel);
                    if (result.Success)
                    {
                        GetFilter();
                        return RedirectToAction("Index", GetRoutesValues());
                    }
                    else
                    {
                        foreach (var item in result.Messages)
                        {
                            ModelState.AddModelError(item.ResourceKey, LocalizedExtensions.GetText(item.ResourceKey));
                        }
                    }
                }
                else
                {
                    return HttpNotFound();
                }
            }
            GetFilter();
            InitializeEditViewModel(viewModel);
            FromEntityToViewModel(entity, viewModel);
            return View(EditView, viewModel);
        }

        [HttpPost]
        public virtual ActionResult Delete(TId id)
        {
            var result = ExecuteDelete(id);
            GetFilter();
            return RedirectToAction("Index", GetRoutesValues());
        }

        #region Protected Members

        protected virtual void InitializeEditViewModel(TEditVM viewModel)
        {

        }

        protected TEntity CreateEntity(TEditVM viewModel)
        {
            TEntity entity = new TEntity();
            FromViewModelToEntity(viewModel, entity);
            return entity;
        }

        protected TEditVM CreateViewModel(TEntity entity)
        {
            TEditVM viewModel = new TEditVM();
            InitializeEditViewModel(viewModel);
            FromEntityToViewModel(entity, viewModel);
            return viewModel;
        }

        protected virtual void FromViewModelToEntity(TEditVM viewModel, TEntity entity)
        {
            _mappingProvider.Map(viewModel, entity);
        }

        protected virtual void FromEntityToViewModel(TEntity entity, TEditVM viewModel)
        {
            _mappingProvider.Map(entity, viewModel);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.RouteData = new ViewDataDictionary();
            FillViewData();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (!Request.IsAjaxRequest()) return;

            ConfigureCache();
        }

        protected virtual int CurrentPage
        {
            get { return Convert.ToInt32(Request.Params["page"] ?? "1"); }
        }

        protected RouteValueDictionary GetRoutesValues()
        {
            var result = new RouteValueDictionary();
            foreach (var item in ViewBag.RouteData)
            {
                result.Add(item.Key, item.Value);
            }
            return result;
        }

        protected virtual void FillViewData()
        {
            ViewBag.RouteData["page"] = CurrentPage;
        }

        protected virtual void ConfigureCache()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Today.AddYears(-1));
        }

        #region Actions

        protected virtual ServiceResult ExecuteInsert(TEntity entity, TEditVM viewModel)
        {
            var result = _service.Insert(entity);
            return result;
        }

        protected virtual ServiceResult ExecuteUpdate(TEntity entity, TEditVM viewModel)
        {
            var result = _service.Update(entity);
            return result;
        }

        protected virtual ServiceResult ExecuteDelete(TId id)
        {
            var result = _service.Delete(id);
            return result;
        }

        protected virtual TListVM ExecuteList(int page)
        {
            var filter = GetFilter();
            InitializeFilter(filter);
            var query = ApplyFilter(_service.GetAll(), filter);
            return new TListVM
            {
                CurrentPage = page,
                Items = query.ToPage<TEntity>(page, PageSize).ToList(),
                PageSize = PageSize,
                TotalItems = query.Count(),
                Filter = filter
            };
        }

        protected virtual IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> items, TFilterVM filter)
        {
            return items;
        }

        protected virtual TFilterVM GetFilter()
        {
            var f = new TFilterVM();
            var filterBase = new FilterVM();

            if (f.GetType().Equals(filterBase.GetType()))
                return null;

            FillFilter(f);
            FillViewData(f);
            return f;
        }

        protected virtual void FillFilter(TFilterVM filter)
        {
            TryUpdateModel(filter);
        }

        protected virtual void InitializeFilter(TFilterVM filter)
        {

        }

        protected virtual void FillViewData(TFilterVM filter)
        {

        }

        protected string GetParamFromRoute(string value, string defaultValue)
        {
            if (RouteData.Values[value] != null)
                // Keep an eye on this
                return (string)RouteData.Values[value];
            return defaultValue;
        }

        protected string GetParamFromRequest(string value, string defaultValue)
        {
            if (Request.Params[value] != null)
                // Keep an eye on this
                return (string)Request.Params[value];
            return defaultValue;
        }

        #endregion

        #endregion


        
    }
}
