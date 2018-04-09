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