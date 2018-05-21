using System;
using System.Collections;
using System.Collections.Generic;
using Dolittle.Types;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read
{
    /// <summary>
    /// In startup, create an override of public void ConfigureServicesCustom(IServiceCollection services).
    /// Register IReadModule with s => new ReadModule(AppDomain.CurrentDomain).
    /// Then instantiate the service with services.BuildServiceProvider().GetService<IReadModule></IReadModule>
    ///     ();
    /// </summary>
    public interface IReadModule
    {
        //void RegisterReadModelClassMaps(AppDomain appDomain);
    }
}