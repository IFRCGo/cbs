/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dolittle.Collections;
using Dolittle.Concepts.Serialization.Json;
using Dolittle.Logging;
using Dolittle.Applications;
using Dolittle.Applications.Serialization.Json;
using Dolittle.Runtime.Events;
using Dolittle.Runtime.Events.Publishing;
using Dolittle.Runtime.Events.Publishing.InProcess;
using Dolittle.Serialization.Json;
using Newtonsoft.Json;

namespace Infrastructure.AspNet
{

    /// <summary>
    /// Provides converters related to concepts for Json serialization purposes
    /// </summary>
    public class ConvertersProvider : ICanProvideConverters
    {
        readonly IApplicationArtifactIdentifierStringConverter _applicationArtifactIdentifierStringConverter;

        /// <summary>
        /// Initializes a new instance 
        /// </summary>
        /// <param name="applicationArtifactIdentifierStringConverter"><see cref="IApplicationArtifactIdentifierStringConverter"/> for converting to and from <see cref="IApplicationArtifactIdentifier"/></param>
        public ConvertersProvider(IApplicationArtifactIdentifierStringConverter applicationArtifactIdentifierStringConverter)
        {
            _applicationArtifactIdentifierStringConverter = applicationArtifactIdentifierStringConverter;
        }

        /// <inheritdoc/>&
        public IEnumerable<JsonConverter> Provide()
        {
            return new JsonConverter[] {
                new ConceptConverter(),
                new EventSourceVersionConverter(),
                new ApplicationArtifactIdentifierJsonConverter(_applicationArtifactIdentifierStringConverter)
            };
        }
    }    
   
}