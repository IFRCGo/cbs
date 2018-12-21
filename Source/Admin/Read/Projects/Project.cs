/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using Concepts.Projects;
using Read.NationalSocieties;
using Read.Users;

namespace Read.Projects
{
    public class Project : IReadModel
    {
        public ProjectId Id { get; set; }
        public ProjectName Name { get; set; }
        public User DataOwner { get; set; }
        public NationalSociety NationalSociety { get; set; }
        public int SurveillanceContext { get; set; }
        //TODO Change to IList<ProjectHealthRisk>
        public ProjectHealthRisk[] HealthRisks { get; set; }
        //TODO Change to IList<User>
        public User[] DataVerifiers { get; set; }

        public string SmsProxy { get; set; }
    }
}