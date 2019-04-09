using System;
using System.Collections.Generic;
using System.IO;
using Concepts.SMS.Gateways;
using Dolittle.IO;
using Dolittle.Lifecycle;
using Dolittle.Serialization.Json;
using Dolittle.Tenancy;

namespace Core.GatewayEndpoints
{
    [Singleton]
    public class TenantMapper : ITenantMapper
    {
        const string MappingFilePathVariableName = "SMSEAGLE_APIKEY_TENANT_PATH";

        readonly Dictionary<string, Guid> _mappings;
        readonly IFileSystem _fileSystem;
        readonly string _filePath;
        readonly ISerializer _serializer;

        public TenantMapper(IFileSystem fileSystem, ISerializer serializer)
        {
            _mappings = new Dictionary<string, Guid>();
            _fileSystem = fileSystem;
            _filePath = Environment.GetEnvironmentVariable(MappingFilePathVariableName);
            _serializer = serializer;

            ThrowIfMappingFileCannotBeAccessed();
            LoadFile();
        }

        void ThrowIfMappingFileCannotBeAccessed()
        {
            if (_filePath == null)
            {
                throw new TenantMapperFileNotAccessible($"Environmental variable '{MappingFilePathVariableName}' was not set.");
            }

            if (_fileSystem.Exists(_filePath))
            {
                try
                {
                    _fileSystem.ReadAllText(_filePath);
                }
                catch (Exception ex)
                {
                    throw new TenantMapperFileNotAccessible($"The file '{_filePath}' could not be read.", ex);
                }
            }
            else
            {
                try
                {
                    _fileSystem.WriteAllText(_filePath, "{}");
                }
                catch (Exception ex)
                {
                    throw new TenantMapperFileNotAccessible($"The file '{_filePath}' could not be written.", ex);
                }
            }
        }

        void LoadFile()
        {
            var content = _fileSystem.ReadAllText(_filePath);
            foreach (var mapping in _serializer.FromJson<Dictionary<string,Guid>>(content))
            {
                _mappings[mapping.Key] = mapping.Value;
            }
        }

        void SaveFile()
        {
            var content = _serializer.ToJson(_mappings);
            _fileSystem.WriteAllText(_filePath, content);
        }

        public TenantId GetTenantFor(ApiKey apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return TenantId.Unknown;
            }
            if (_mappings.TryGetValue(apiKey, out var tenantId))
            {
                return tenantId;
            }
            return TenantId.Unknown;
        }

        public void SetTenantFor(ApiKey apiKey, TenantId tenantId)
        {
            _mappings[apiKey] = tenantId;
            SaveFile();
        }
    }
}