/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands;

namespace Domain.Reporting.HealthRisks.TestData
{
    public class PopulateHealthRiskTestData : ICommand
    {
        public Guid Id { get; set; }
    }
}