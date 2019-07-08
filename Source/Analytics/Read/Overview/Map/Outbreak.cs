using Dolittle.ReadModels;
using System;
using System.Collections;
using System.Collections.Generic;
using Concepts;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
namespace Read.Overview.Map
{
    public class Outbreak : IReadModel
    {
        public Day Id { get; set; }
        

    }

}
