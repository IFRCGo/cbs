/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Reflection;
using Dolittle.Collections;
using Dolittle.Concepts.Serialization.Json;
using Dolittle.Logging;
using Dolittle.Applications;
using Dolittle.Runtime.Events;
using Dolittle.Runtime.Events.Publishing;
using Dolittle.Runtime.Events.Publishing.InProcess;
using Dolittle.Serialization.Json;
using Newtonsoft.Json;

namespace Infrastructure.AspNet
{


    /// <summary>
    /// Represents a <see cref="JsonConverter"/> that can serialize and deserialize <see cref="EventSourceVersion"/>
    /// </summary>
    public class EventSourceVersionConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return typeof(EventSourceVersion).GetTypeInfo().IsAssignableFrom(objectType);
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return EventSourceVersion.FromCombined((double)reader.Value);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((EventSourceVersion)value).Combine());
        }
    }
    
}