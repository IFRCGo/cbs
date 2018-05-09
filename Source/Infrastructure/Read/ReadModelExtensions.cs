using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Dolittle.Concepts;
using Dolittle.ReadModels;
using MongoDB.Bson;
namespace Infrastructure.Read
{
    public static class ReadModelExtensions
    {
        public static object Get_id<T>(this T readModel)
            where T : IReadModel
        {
            return GetObjectIdFrom(readModel);
        }

        // This part is copied from https://github.com/dolittle-extensions/ReadModels.MongoDB/blob/master/Source/ReadModelRepositoryFor.cs

        private static BsonValue GetObjectIdFrom<T>(T entity)
            where T : IReadModel
        {
            try
            {
                var propInfo = GetIdProperty(entity);
                object id = propInfo.GetValue(entity);

                return GetIdAsBsonValue(id);
            }
            catch (Exception e) //TODO: Change to catch explicit Exceptions when I know what kind 
            {
                var type = entity.GetType();
                throw new ReadModelHasNoIdField(
                    $"Type {type.FullName} does not provide a BSon Class Mapping for _id",
                    e
                    );
            }
        }

        private static BsonValue GetIdAsBsonValue(object id)
        {
            var idVal = id;
            if (id.IsConcept())
                idVal = id.GetConceptValue();

            var idAsValue = BsonValue.Create(idVal);
            return idAsValue;
        }

        private static PropertyInfo GetIdProperty<T>(T entity)
            where T : IReadModel
        {
            return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).First(p => p.Name.ToLowerInvariant() == "id");
        }
    }
}