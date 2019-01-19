/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.IO;
using Read.Management.DataCollectors;

namespace Core.Utility
{
    public interface IDataCollectorExporter
    {
        string GetMIMEType();
        string GetFileExtension();
        bool WriteDataCollectors(IEnumerable<DataCollector> dataCollectors, Stream stream);
    }
}