/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.ReadModels;
using Events.Project;
using Read.NationalSocietyFeatures;
using Read.UserFeatures;

namespace Read.ProjectFeatures
{
    public class Project : IReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public User DataOwner { get; set; }
        public NationalSociety NationalSociety { get; set; }
        
        public ProjectSurveillanceContext SurveillanceContext { get; set; }

        public ProjectHealthRisk[] HealthRisks { get; set; }

        public User[] DataVerifiers { get; set; }

        public string SmsProxy { get; set; }
    }
}