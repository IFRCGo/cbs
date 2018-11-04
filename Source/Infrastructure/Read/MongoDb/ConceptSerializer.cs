using System;
using System.Reflection;
using Dolittle.Concepts;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Read.MongoDb
{
    /// <inheritdoc/>
    public class ConceptSerializer<T> : IBsonSerializer<T>
    {
        /// <inheritdoc/>
        public Type ValueType { get; }
        /// <inheritdoc/>

        public ConceptSerializer()
        {
            ValueType = typeof(T);

            if (!ValueType.IsConcept())
                throw new Exception("Not a concept");

        }

        /// <inheritdoc/>
        public T Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;

            var actualType = args.NominalType;

            object value = null;

            BsonType bsonType = bsonReader.GetCurrentBsonType();

            var valueType = actualType.GetConceptValueType();
            if (bsonType == BsonType.Document) // It should be a Concept object
            {
                bsonReader.ReadStartDocument();
                var keyName = bsonReader.ReadName(Utf8NameDecoder.Instance);
                if (keyName == "Value" || keyName == "value")
                {
                    value = GetDeserializedValue(valueType, ref bsonReader);
                    bsonReader.ReadEndDocument();
                }
                else
                {
                    //Throw exception
                }

            }
            else
            {
                value = GetDeserializedValue(valueType, ref bsonReader);
            }

            dynamic concept = ConceptFactory.CreateConceptInstance(ValueType, value);

            return concept;
        }

        object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return this.Deserialize(context, args); 
        }
        /// <inheritdoc/>
        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, T value)
        {
            var underlyingValue = value?.GetType().GetTypeInfo().GetProperty("Value").GetValue(value, null);
            var nominalType = args.NominalType;
            var underlyingValueType = nominalType.GetConceptValueType();

            var bsonWriter = context.Writer;

            if (underlyingValueType == typeof(Guid))
            {
                var guid = (Guid)(underlyingValue ?? default(Guid));
                var guidAsBytes = guid.ToByteArray();
                bsonWriter.WriteBinaryData(new BsonBinaryData(guidAsBytes, BsonBinarySubType.UuidLegacy, GuidRepresentation.CSharpLegacy));
            }
            else if (underlyingValueType == typeof(double))
                bsonWriter.WriteDouble((double)(underlyingValue ?? default(double)));
            else if (underlyingValueType == typeof(float))
                bsonWriter.WriteDouble((double)(underlyingValue ?? default(double)));
            else if (underlyingValueType == typeof(Int32))
                bsonWriter.WriteInt32((Int32)(underlyingValue ?? default(Int32)));
            else if (underlyingValueType == typeof(Int64))
                bsonWriter.WriteInt64((Int64)(underlyingValue ?? default(Int64)));
            else if (underlyingValueType == typeof(bool))
                bsonWriter.WriteBoolean((bool)(underlyingValue ?? default(bool)));
            else if (underlyingValueType == typeof(string))
                bsonWriter.WriteString((string)(underlyingValue ?? string.Empty));
            else if (underlyingValueType == typeof(decimal))
                bsonWriter.WriteString(underlyingValue?.ToString() ?? default(decimal).ToString());
        }
        /// <inheritdoc/>
        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            var underlyingValue = value?.GetType().GetTypeInfo().GetProperty("Value").GetValue(value, null);
            var nominalType = args.NominalType;
            var underlyingValueType = nominalType.GetConceptValueType();

            var bsonWriter = context.Writer;

            if (underlyingValueType == typeof(Guid))
            {
                var guid = (Guid)(underlyingValue ?? default(Guid));
                var guidAsBytes = guid.ToByteArray();
                bsonWriter.WriteBinaryData(new BsonBinaryData(guidAsBytes, BsonBinarySubType.UuidLegacy, GuidRepresentation.CSharpLegacy));
            }
            else if (underlyingValueType == typeof(double))
                bsonWriter.WriteDouble((double)(underlyingValue ?? default(double)));
            else if (underlyingValueType == typeof(float))
                bsonWriter.WriteDouble((double)(underlyingValue ?? default(double)));
            else if (underlyingValueType == typeof(Int32))
                bsonWriter.WriteInt32((Int32)(underlyingValue ?? default(Int32)));
            else if (underlyingValueType == typeof(Int64))
                bsonWriter.WriteInt64((Int64)(underlyingValue ?? default(Int64)));
            else if (underlyingValueType == typeof(bool))
                bsonWriter.WriteBoolean((bool)(underlyingValue ?? default(bool)));
            else if (underlyingValueType == typeof(string))
                bsonWriter.WriteString((string)(underlyingValue ?? string.Empty));
            else if (underlyingValueType == typeof(decimal))
                bsonWriter.WriteString(underlyingValue?.ToString() ?? default(decimal).ToString());
        }

        object GetDeserializedValue(Type valueType, ref IBsonReader bsonReader)
        {
            var bsonType = bsonReader.CurrentBsonType;

            if (bsonType == BsonType.Null)
            {
                bsonReader.ReadNull();
                return null;
            }
            if (valueType == typeof(Guid))
            {
                var binaryData = bsonReader.ReadBinaryData();
                return binaryData.ToGuid();
            }
            else if (valueType == typeof(double))
                return bsonReader.ReadDouble();
            else if (valueType == typeof(float))
                return (float)bsonReader.ReadDouble();
            else if (valueType == typeof(Int32))
                return bsonReader.ReadInt32();
            else if (valueType == typeof(Int64))
                return bsonReader.ReadInt64();
            else if (valueType == typeof(bool))
                return bsonReader.ReadBoolean();
            else if (valueType == typeof(string))
                return bsonReader.ReadString();
            else if (valueType == typeof(decimal))
                return decimal.Parse(bsonReader.ReadString());

            throw new Exception();
        }
    }
}