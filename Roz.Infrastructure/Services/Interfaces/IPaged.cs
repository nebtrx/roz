namespace Roz.Infrastructure.Services
{
    public interface IPaged
    {
        int CurrentPage { get; set; }

        int PageSize { get; set; }

        long TotalCount { get; set; }
    }
}