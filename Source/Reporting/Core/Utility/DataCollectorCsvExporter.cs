/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Concepts.DataCollectors;
using Read.Management.DataCollectors;

namespace Core.Utility
{
    public class DataCollectorCsvExporter : IDataCollectorExporter
    {
        public string GetMIMEType()
        {
            return "text/csv";
        }

        public string GetFileExtension()
        {
            return ".csv";  
        }

        public bool WriteDataCollectors(IEnumerable<DataCollector> dataCollectors, Stream stream)
        {
            var writer = new StreamWriter(stream, Encoding.UTF8);

            writer.WriteLine("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\"", "Full Name", "Display Name", "Year of birth", "Sex", "Preferred language", "Lat. / Long.", "Region", "District", "Village", "Phonenumbers", "Registered at", "Last report received at");

            foreach (var dataCollector in dataCollectors)
            {
                var fullName = dataCollector.FullName;
                var displayName = dataCollector.DisplayName;
                var yearOfBirth = dataCollector.YearOfBirth.ToString();
                var sex = Enum.GetName(typeof(Sex), dataCollector.Sex);
                var preferredLanguage = Enum.GetName(typeof(Language), dataCollector.Sex);
                var location = dataCollector.Location.Latitude + ", " + dataCollector.Location.Longitude;
                var region = dataCollector.Region ?? "Unknown";
                var district = dataCollector.District ?? "Unknown";
                var village = dataCollector.Village ?? "Unknown";
                var phoneNumbers = string.Join(", ", dataCollector.PhoneNumbers.Select(pn => pn.Value));
                var registeredAt = dataCollector.RegisteredAt.ToString("d");
                // TODO: 
                // var lastReportReceivedAt = dataCollector.LastReportRecievedAt.HasValue
                //     ? dataCollector.LastReportRecievedAt.Value.ToString("d")
                //     : "";


                writer.WriteLine("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\"", fullName, displayName, yearOfBirth, sex, preferredLanguage, location, region, district, village, phoneNumbers, registeredAt, DateTimeOffset.UtcNow);
            }

            writer.Flush();
            return true;
        }
    }
}