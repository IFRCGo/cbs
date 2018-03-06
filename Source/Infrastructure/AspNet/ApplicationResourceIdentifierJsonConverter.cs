/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using doLittle.Collections;
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
    /// Represents a <see cref="JsonConverter"/> that can serialize and deserialize <see cref="IApplicationArtifactIdentifier"/>
    /// </summary>
    public class ApplicationResourceIdentifierJsonConverter : JsonConverter
    {
        IApplicationResourceIdentifierConverter _converter;

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationArtifactIdentifierJsonConverter"/>
        /// </summary>
        /// <param name="converter"><see cref="IApplicationArtifactIdentifierStringConverter"/> for converting to and from string representations</param>
        public ApplicationResourceIdentifierJsonConverter(IApplicationResourceIdentifierConverter converter)
        {
            _converter = converter;
        }

        /// <inheritdoc/>
        public override bool CanRead { get { return true; } }

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return typeof(IApplicationResourceIdentifier).GetTypeInfo().IsAssignableFrom(objectType);
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var identifierAsString = reader.Value.ToString();
            var identifier = _converter.FromString(identifierAsString);
            return identifier;
        }

        /// <inheritdoc/>
        public override bool CanWrite { get { return true; } }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var identifier = value as IApplicationResourceIdentifier;
            if( identifier != null )
            {
                var identifierAsString = _converter.AsString(identifier);
                writer.WriteValue(identifierAsString);
            }
        }
    }
}