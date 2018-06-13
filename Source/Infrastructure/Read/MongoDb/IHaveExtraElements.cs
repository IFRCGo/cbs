using System.Collections.Generic;
using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Read.MongoDb
{
    /// <summary>
    /// Defines a Read Model class that has extra bson documents.
    /// </summary>
    public interface IHaveExtraElements : ISupportInitialize
    {
        IDictionary<string, object> ExtraElements {get; set;}
    }
}