/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Linq;
using doLittle.Events.Processing;
using Events;
using Read.AutomaticReplyMessages;
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
        private readonly IReplyMessages _replyMessages;

        public ProjectEventProcessor(IProjects projects
            , IUsers users
            , INationalSocieties nationalSocieties
            , IProjectHealthRiskVersions projectHealthRiskVersions, IReplyMessages replyMessages)
        {
            _projects = projects;
            _users = users;
            _nationalSocieties = nationalSocieties;
            _projectHealthRiskVersions = projectHealthRiskVersions;
            _replyMessages = replyMessages;
        }

        public void Process(ProjectCreated @event)
        {
            var project = new Project
            {
                Id = @event.Id,
                NationalSociety = _nationalSocieties.GetById(@event.NationalSocietyId),
                DataOwner = _users.GetById(@event.DataOwnerId),
                Name = @event.Name,
                SurveillanceContext = @event.SurveillanceContext
            };
            _projects.Save(project);
        }

        public void Process(ProjectUpdated @event)
        {
            var project = _projects.GetById(@event.Id);
            project.NationalSociety = _nationalSocieties.GetById(@event.NationalSocietyId);
            project.DataOwner = _users.GetById(@event.DataOwnerId);
            project.Name = @event.Name;
            project.SurveillanceContext = @event.SurveillanceContext;
            project.SmsProxy = @event.SmsProxy;
            _projects.Save(project);
        }

        public void Process(ProjectDeleted @event)
        {
            _projects.Delete(@event.ProjectId);
        }

        public void Process(ProjectHealthRiskAdded @event)
        {
            var project = _projects.GetById(@event.ProjectId);
            project.HealthRisks = new List<ProjectHealthRisk>(project.HealthRisks)
            {
                new ProjectHealthRisk
                {
                    HealthRiskId = @event.HealthRiskId,
                    Threshold = @event.Threshold
                }
            }.ToArray();
            _projects.Save(project);
        }

        public void Process(ProjectHealthRiskThresholdUpdate @event)
        {
            var project = _projects.GetById(@event.ProjectId);
            var healthRisk = project.HealthRisks?.FirstOrDefault(v => v.HealthRiskId == @event.HealthRiskId);

            if (healthRisk == null)
            {
                healthRisk = new ProjectHealthRisk();
                project.HealthRisks = (project.HealthRisks ?? new ProjectHealthRisk[0]).Union(new[] {healthRisk})
                    .ToArray();
            }

            healthRisk.HealthRiskId = @event.HealthRiskId;
            healthRisk.Threshold = @event.Threshold;
            _projects.Save(project);

            _projectHealthRiskVersions.Append(project.Id, healthRisk, System.DateTimeOffset.UtcNow);
        }

        public void Process(DataVerifierAdded @event)
        {
            var project = _projects.GetById(@event.ProjectId);
            var user = _users.GetById(@event.UserId);
            project.DataVerifiers = new List<User>(project.DataVerifiers) {user}.ToArray();
            _projects.Save(project);
        }

        public void Process(DataVerifierRemoved @event)
        {
            var project = _projects.GetById(@event.ProjectId);
            var user = _users.GetById(@event.UserId);
            var list = new List<User>(project.DataVerifiers);
            if (list.Remove(user))
            {
                project.DataVerifiers = list.ToArray();
                _projects.Save(project);
            }
        }

        public void Process(ReplyMessageConfigUpdated @event)
        {
            _replyMessages.Save(new ReplyMessagesConfig
            {
                Messages = @event.Messages
            });

        }
    }
    
}