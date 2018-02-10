/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Domain
{
    public class AddProjectHealthRisk
    {
        public Guid ProjectId { get; set;  }
        public Guid HealthRiskId { get; set; }
        public int Threshold { get; set; }
    }
}