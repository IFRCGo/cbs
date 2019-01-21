/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Concepts.DataCollectors;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Read.Management.DataCollectors;

namespace Core.Utility
{
    public class DataCollectorExcelExporter : IDataCollectorExporter
    {
        public string GetMIMEType()
        {
            return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        }

        public string GetFileExtension()
        {
            return ".xlsx";
        }

        public bool WriteDataCollectors(IEnumerable<DataCollector> dataCollectors, Stream stream)
        {
            var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);
            WorkbookPart workbook = document.AddWorkbookPart();
            workbook.Workbook = new Workbook();
            Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());

            // Create a sheet in the document
            var data = new SheetData();
            WorksheetPart worksheet = workbook.AddNewPart<WorksheetPart>();
            worksheet.Worksheet = new Worksheet(data);
            Sheet sheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheet), SheetId = 1, Name = "Case Reports" };
            sheets.Append(sheet);


            uint rowIndex = 0;
            // Add some headers
            {
                var row = new Row { RowIndex = ++rowIndex };
                data.Append(row);

                var headers = new SortedDictionary<string, string>
                    {
                        { "A", "Full Name" },
                        { "B", "Display Name" },
                        { "C", "Year of birth" },
                        { "D", "Sex" },
                        { "E", "PreferredLanguage" },
                        { "F", "Lat. / Long." },
                        { "G", "Region" },
                        { "H", "District" },
                        { "I", "Village" },
                        { "J", "Phonenumbers" },
                        { "K", "Registered at" },
                        { "L", "Last Report Recieved At" }
                    };

                foreach (var header in headers)
                {
                    var cell = new Cell { CellReference = header.Key + rowIndex };
                    row.Append(cell);
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell.CellValue = new CellValue(header.Value);
                }
            }

            // Insert data
            foreach (var dataCollector in dataCollectors.OrderBy(e => e.RegisteredAt))
            {
                var row = new Row { RowIndex = ++rowIndex };
                data.Append(row);

                var fullName = new Cell { CellReference = "A" + rowIndex };
                row.Append(fullName);
                fullName.DataType = new EnumValue<CellValues>(CellValues.String);
                fullName.CellValue = new CellValue(dataCollector.FullName);

                var displayName = new Cell { CellReference = "B" + rowIndex };
                row.Append(displayName);
                displayName.DataType = new EnumValue<CellValues>(CellValues.String);
                displayName.CellValue = new CellValue(dataCollector.DisplayName);

                var yearOfBirth = new Cell { CellReference = "C" + rowIndex };
                row.Append(yearOfBirth);
                yearOfBirth.DataType = new EnumValue<CellValues>(CellValues.Number);
                yearOfBirth.CellValue = new CellValue(dataCollector.YearOfBirth.ToString());

                var sex = new Cell { CellReference = "D" + rowIndex };
                row.Append(sex);
                sex.DataType = new EnumValue<CellValues>(CellValues.String);
                sex.CellValue = new CellValue(Enum.GetName(typeof(Sex), dataCollector.Sex));

                var preferredLanguage = new Cell { CellReference = "E" + rowIndex };
                row.Append(preferredLanguage);
                preferredLanguage.DataType = new EnumValue<CellValues>(CellValues.String);
                preferredLanguage.CellValue = new CellValue(Enum.GetName(typeof(Language), dataCollector.PreferredLanguage));

                var location = new Cell { CellReference = "F" + rowIndex };
                row.Append(location);
                location.DataType = new EnumValue<CellValues>(CellValues.String);
                location.CellValue = new CellValue(dataCollector.Location.Latitude.ToString() + ", " + dataCollector.Location.Longitude.ToString());

                var region = new Cell { CellReference = "G" + rowIndex };
                row.Append(region);
                region.DataType = new EnumValue<CellValues>(CellValues.String);
                region.CellValue = new CellValue(dataCollector.Region ?? "Unknown");

                var district = new Cell { CellReference = "H" + rowIndex };
                row.Append(district);
                district.DataType = new EnumValue<CellValues>(CellValues.String);
                district.CellValue = new CellValue(dataCollector.District ?? "Unknown");

                var village = new Cell { CellReference = "I" + rowIndex };
                row.Append(village);
                village.DataType = new EnumValue<CellValues>(CellValues.String);
                village.CellValue = new CellValue(dataCollector.Village ?? "Unknown");

                var phoneNumbers = new Cell { CellReference = "J" + rowIndex };
                row.Append(phoneNumbers);
                phoneNumbers.DataType = new EnumValue<CellValues>(CellValues.String);
                phoneNumbers.CellValue = new CellValue(string.Join(", ", dataCollector.PhoneNumbers.Select(pn => pn.Value)));

                var registeredAt = new Cell { CellReference = "K" + rowIndex };
                row.Append(registeredAt);
                registeredAt.DataType = new EnumValue<CellValues>(CellValues.Date);
                registeredAt.CellValue = new CellValue(dataCollector.RegisteredAt);

                var lastReportRecievedAt = new Cell { CellReference = "L" + rowIndex };
                row.Append(lastReportRecievedAt);
                lastReportRecievedAt.DataType = new EnumValue<CellValues>(CellValues.Date);
                lastReportRecievedAt.CellValue = new CellValue(DateTimeOffset.UtcNow/* TODO: dataCollector.LastReportRecievedAt ?? dataCollector.RegisteredAt*/);
            }

            // Save the document in memory, and serve to client
            workbook.Workbook.Save();
            document.Close();
            return true;
        }
    }
}