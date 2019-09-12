/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class TotalReports : IReadModel
    {
        public string Id { get; set; }
        public int Reports { get; set; }
    }
}
