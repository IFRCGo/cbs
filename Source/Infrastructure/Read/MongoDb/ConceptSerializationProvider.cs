using System;
using Dolittle.Concepts;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read.MongoDb
{
    /// <summary>
    /// 
    /// </summary>
    public class ConceptSerializationProvider : IBsonSerializationProvider
    {
        /// <inheritdoc/>
        public IBsonSerializer GetSerializer(Type type)
        {
            if (type.IsConcept())
            {
                var createConceptSerializerGenericMethod = this.GetType().GetMethod("CreateConceptSerializer").MakeGenericMethod(type);
                dynamic serializer = createConceptSerializerGenericMethod.Invoke(null, new object[]{});
                return serializer;
            }
                
            return null;
        }

        public static ConceptSerializer<T> CreateConceptSerializer<T>()
        {
            return new ConceptSerializer<T>();
        }
    }
}