using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dolittle.ReadModels;

namespace Infrastructure.Read.Migration
{
    public static class IQueryableExtentions
    {
        public static IQueryable<T> MigrateQuery<T>(this IQueryable<T> query, ICanMigrate<T> migrator)
            where T : IReadModel
        {
            var queryAsEnumerable = query.AsEnumerable();
            IList<T> readModels = new List<T>();

            foreach (var item in queryAsEnumerable)
            {
                readModels.Add(migrator.GetMigratedReadModel(item));
            }
            return readModels.AsQueryable();

        }

        public static IOrderedQueryable<T> OrderByField<T>(this IQueryable<T> source, string fieldName, bool ascending)
        {
            var operation = ascending ? "OrderBy" : "OrderByDescending";
            var type = typeof(T);
            var property = type.GetProperty(fieldName);
            var parameter = Expression.Parameter(type, "p");
            if (property != null)
            {
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                var resultExp = Expression.Call(typeof(Queryable), operation, new[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
                return source.Provider.CreateQuery<T>(resultExp) as IOrderedQueryable<T>;
            }
            throw new ArgumentException($"Fieldname '{fieldName}' not found");
        }
    }
}