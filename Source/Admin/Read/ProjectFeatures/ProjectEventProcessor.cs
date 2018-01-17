/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Events.Processing;
using Events;
using System.Linq;
using Read.NationalSocietyFeatures;
using Read.UserFeatures;

namespace Read.ProjectFeatures
{
    public class ProjectEventProcessor : ICanProcessEvents
    {
        private readonly IProjects _projects;
        private readonly IUsers _users;
        private readonly INationalSocieties _nationalSocieties;
        private readonly IProjectHealthRiskVersions _projectHealthRiskVersions;

        public ProjectEventProcessor(IProjects projects
            , IUsers users
            , INationalSocieties nationalSocieties
            , IProjectHealthRiskVersions projectHealthRiskVersions)
        {
            _projects = projects;
            _users = users;
            _nationalSocieties = nationalSocieties;
            _projectHealthRiskVersions = projectHealthRiskVersions;
        }

        public void Process(ProjectCreated @event)
        {
            var project = _projects.GetById(@event.Id);
            project.NationalSociety = _nationalSocieties.GetById(@event.NationalSocietyId);
            project.DataOwner = _users.GetById(@event.DataOwnerId);
            project.Name = @event.Name;
            project.SurveillanceContex = @event.SurveillanceContex;
            _projects.Save(project);
        }

        public void Process(ProjectHealthRiskThresholdSet @event)
        {
            var project = _projects.GetById(@event.ProjectId);
            var healthRisk = project.HealthRisks?.FirstOrDefault(v=>v.HealthRiskId == @event.HealthRiskId);

            if (healthRisk == null)
            {
                healthRisk = new ProjectHealthRisk();
                project.HealthRisks = (project.HealthRisks ?? new ProjectHealthRisk[0]).Union(new[] { healthRisk }).ToArray();
            }

            healthRisk.HealthRiskId = @event.HealthRiskId;
            healthRisk.Threshold = @event.Threshold;
            _projects.Save(project);

            _projectHealthRiskVersions.Append(project.Id, healthRisk, System.DateTimeOffset.UtcNow);
        }
    }
}