/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using doLittle.Collections;
using doLittle.Concepts.Serialization.Json;
using doLittle.Logging;
using doLittle.Runtime.Applications;
using doLittle.Runtime.Events;
using doLittle.Runtime.Events.Publishing;
using doLittle.Runtime.Events.Publishing.InProcess;
using doLittle.Serialization.Json;
using Newtonsoft.Json;

namespace Infrastructure.AspNet
{

    /// <summary>
    /// Provides converters related to concepts for Json serialization purposes
    /// </summary>
    public class ConvertersProvider : ICanProvideConverters
    {
        readonly IApplicationResourceIdentifierConverter _applicationResourceIdentifierConverter;

        /// <summary>
        /// Initializes a new instance 
        /// </summary>
        /// <param name="applicationResourceIdentifierConverter"><see cref="IApplicationResourceIdentifierConverter"/> for converting to and from <see cref="IApplicationResourceIdentifier"/></param>
        public ConvertersProvider(IApplicationResourceIdentifierConverter applicationResourceIdentifierConverter)
        {
            _applicationResourceIdentifierConverter = applicationResourceIdentifierConverter;
        }

        /// <inheritdoc/>
        public IEnumerable<JsonConverter> Provide()
        {
            return new JsonConverter[] {
                new ConceptConverter(),
                new EventSourceVersionConverter(),
                new ApplicationResourceIdentifierJsonConverter(_applicationResourceIdentifierConverter)
            };
        }
    }    
   
}