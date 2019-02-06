using System;
using System.Linq;
using System.Linq.Expressions;

namespace Read.Reporting.CaseReportsForListing
{
    public static class QueryExtensions
    {
        public static IQueryable<T> OrderByFieldName<T>(this IQueryable<T> source, string fieldName, bool orderAscending)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                return source;

            var type = typeof(T);
            var property = type.GetProperty(fieldName);
            if (property == null)
                return source;
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), orderAscending ? "OrderBy" : "OrderByDescending", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }
    }
}