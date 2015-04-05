using System.Linq;
using Roz.WebApp;
using Roz.WebApp.Models;

namespace Roz.WebApp
{
    public class MappingConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Book, BookVM>()
                .ForMember(vm => vm.Reviews, m => m.MapFrom(s => s.Reviews.ToList()));
            AutoMapper.Mapper.CreateMap<Review, ReviewVM>();
        }
    }
}