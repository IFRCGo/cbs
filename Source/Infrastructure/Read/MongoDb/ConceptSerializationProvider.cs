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
                if(type.IsSubclassOf(typeof(ConceptAs<Guid>)))
                {
                    return new ConceptSerializer<ConceptAs<Guid>>(type);
                }
                else if (type.IsSubclassOf(typeof(ConceptAs<double>)))
                {
                    return new ConceptSerializer<ConceptAs<double>>(type);
                }
                else if (type.IsSubclassOf(typeof(ConceptAs<float>)))
                {
                    return new ConceptSerializer<ConceptAs<float>>(type);
                }
                else if (type.IsSubclassOf(typeof(ConceptAs<Int32>)))
                {
                    return new ConceptSerializer<ConceptAs<Int32>>(type);
                }
                else if (type.IsSubclassOf(typeof(ConceptAs<Int64>)))
                {
                    return new ConceptSerializer<ConceptAs<Int64>>(type);
                }
                else if (type.IsSubclassOf(typeof(ConceptAs<bool>)))
                {
                    return new ConceptSerializer<ConceptAs<bool>>(type);
                }
                else if (type.IsSubclassOf(typeof(ConceptAs<string>)))
                {
                    return new ConceptSerializer<ConceptAs<string>>(type);
                }
                else if (type.IsSubclassOf(typeof(ConceptAs<decimal>)))
                {
                    return new ConceptSerializer<ConceptAs<decimal>>(type);
                }
            }
                
            return null;
        }
    }
}