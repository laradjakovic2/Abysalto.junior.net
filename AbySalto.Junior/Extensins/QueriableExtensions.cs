using System.Linq.Expressions;

namespace AbySalto.Junior.Extensins
{
    public static class QueriableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string? sortBy, string? sortOrder = "asc")
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return source;

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, sortBy);
            var lambda = Expression.Lambda(property, parameter);

            string methodName = sortOrder?.ToLower() == "desc" ? "OrderByDescending" : "OrderBy";

            var result = Expression.Call(
                typeof(Queryable),
                methodName,
                [typeof(T), property.Type],
                source.Expression,
                Expression.Quote(lambda));

            return source.Provider.CreateQuery<T>(result);
        }
    }
}
