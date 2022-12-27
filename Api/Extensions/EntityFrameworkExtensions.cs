using Api.Viewmodels;

namespace Api.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, 
                                                int page = 0, int pageSize = 0) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page == 0 ? 1 : page;
            result.PageSize = pageSize == 0 ? query.Count() : pageSize;
            result.RowCount = query.Count();

            var pageCount = pageSize == 0 ? 1 : (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
        
            var skip = (page - 1) * pageSize;     
            result.Results = page == 0 && pageSize == 0 ? query.ToList() : query.Skip(skip).Take(pageSize).ToList();
        
            return result;
        }
    }
}