/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Dolittle.Events.Processing;
using Events.Admin;
using Events.Projects;
using Events.AutomaticReplyMessages;
using Read.AutomaticReplyMessages;
using Read.NationalSocieties;
using Read.Users;
using Concepts.Projects;
using Dolittle.ReadModels;

namespace Read.Projects
{
    public class ProjectEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<Project> _projects;
        private readonly IReadModelRepositoryFor<User> _users;
        private readonly IReadModelRepositoryFor<NationalSociety> _nationalSocieties;
        private readonly IReadModelRepositoryFor<ProjectHealthRiskVersion> _projectHealthRiskVersions;
        private readonly IReadModelRepositoryFor<ReplyMessagesConfig> _replyMessages;

        public ProjectEventProcessor(IReadModelRepositoryFor<Project> projects
            , IReadModelRepositoryFor<User> users
            , IReadModelRepositoryFor<NationalSociety> nationalSocieties
            , IReadModelRepositoryFor<ProjectHealthRiskVersion> projectHealthRiskVersions,
            IReadModelRepositoryFor<ReplyMessagesConfig> replyMessages)
        {
            _projects = projects;
            _users = users;
            _nationalSocieties = nationalSocieties;
            _projectHealthRiskVersions = projectHealthRiskVersions;
            _replyMessages = replyMessages;
        }

        [EventProcessor("2ddde142-2195-40e4-a177-d17292df9b90")]
        public void Process(ProjectCreated @event)
        {
            var project = new Project
            {
                Id = @event.Id,
                NationalSociety = _nationalSocieties.GetById(@event.NationalSocietyId),
                DataOwner = _users.GetById(@event.DataOwnerId),
                Name = @event.Name,
                SurveillanceContext = @event.SurveillanceContext,
                HealthRisks = new ProjectHealthRisk[0],
                DataVerifiers = new User[0],
                SmsProxy = ""

            };
            _projects.Insert(project);
        }

        [EventProcessor("cb32f42e-5142-4e19-a4e0-04afd8bada9b")]
        public void Process(ProjectUpdated @event)
        {
            var project = _projects.GetById(@event.Id);
            project.NationalSociety = _nationalSocieties.GetById(@event.NationalSocietyId);
            project.DataOwner = _users.GetById(@event.DataOwnerId);
            project.Name = @event.Name;
            project.SurveillanceContext = @event.SurveillanceContext;
            project.SmsProxy = @event.SmsProxy;

            _projects.Update(project);
        }

        [EventProcessor("6db72e4b-cadc-43a7-b12f-ed9275a60ac1")]
        public void Process(ProjectDeleted @event)
        {
            var project = _projects.GetById(@event.ProjectId);
            _projects.Delete(project);
        }
        [EventProcessor("56aa04c3-b5bc-48ac-a45a-9f1efcadce62")]
        public void Process(ProjectHealthRiskAdded @event)
        {
            var project = _projects.GetById(@event.ProjectId);

            var projectHealthRisk = new ProjectHealthRisk
            {
                HealthRiskId = @event.HealthRiskId,
                Threshold = @event.Threshold
            };

            project.HealthRisks.Append(projectHealthRisk);

            _projects.Update(project);
        }
        [EventProcessor("914923d5-21c5-43bf-956a-123218e4d8d1")]
        public void Process(ProjectHealthRiskThresholdUpdate @event)
        {
            var project = _projects.GetById(@event.ProjectId);
            var healthRisk = project.HealthRisks.Single(r => r.HealthRiskId == @event.HealthRiskId);
            healthRisk.Threshold = @event.Threshold;
            //@todo need to be tested
            _projects.Update(project);

            var projectHealthRiskVersion = new ProjectHealthRiskVersion
            {
                ProjectId = project.Id,
                EffectiveFromTime = DateTimeOffset.UtcNow,
                HealthRisk = healthRisk
            };

            _projectHealthRiskVersions.Insert(projectHealthRiskVersion);
        }
        [EventProcessor("ea4b9ace-f4b1-4526-8e4b-601f6727a60f")]
        public void Process(DataVerifierAdded @event)
        {
            //@todo Assumes that user and project exists. Should be verified in BusinessValidator
            var user = _users.GetById(@event.UserId);
            var project = _projects.GetById(@event.ProjectId);
            project.DataVerifiers.Append(user);
        }
        [EventProcessor("15e22196-e233-468f-922c-8ac2b4eda660")]
        public void Process(DataVerifierRemoved @event)
        {
            //@todo Assumes that project exists. Should be verified in BusinessValidator
            //_projects.Update(p => p.Id == @event.ProjectId,
            //    Builders<Project>.Update.PullFilter(p => p.DataVerifiers, u => u.Id == @event.UserId));
        }
        [EventProcessor("fc262fe1-4aaf-497d-91ad-b9876e032f88")]
        public void Process(ReplyMessageConfigUpdated @event)
        {
            //@todo Event should have Id field
            _replyMessages.Insert(new ReplyMessagesConfig
            {
                //FIXME! Event needs to look different!
                //Messages = @event.Messages
            });
        }
    }    
}