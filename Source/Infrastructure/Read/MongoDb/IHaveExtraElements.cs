using System.Collections.Generic;
using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Read.MongoDb
{
    /// <summary>
    /// Defines a Read Model class that has extra bson documents.
    /// ExtraElements will be a dumping place for all extra bson elements when serialized
    /// </summary>
    public interface IHaveExtraElements
    {
        IDictionary<string, object> ExtraElements {get; set;}
    }
}