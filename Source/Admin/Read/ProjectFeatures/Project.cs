/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Security.Cryptography.X509Certificates;
using Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Read.NationalSocietyFeatures;
using Read.UserFeatures;

namespace Read.ProjectFeatures
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public User DataOwner { get; set; }
        public NationalSociety NationalSociety { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EProjectSurveillanceContex SurveillanceContex { get; set; }

        public ProjectHealthRisk[] HealthRisks { get; set; }
    }
}