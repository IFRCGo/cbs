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
                return new ConceptSerializer(type);

            return null;
        }
    }
}