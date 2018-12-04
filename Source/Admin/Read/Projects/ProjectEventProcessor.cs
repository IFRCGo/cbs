/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Dolittle.Events.Processing;
using Events;
using Events.Admin;
using Events.Projects;
using Events.AutomaticReplyMessages;
using MongoDB.Driver;
using Read.AutomaticReplyMessages;
using Read.NationalSocieties;
using Read.Users;
using Concepts.Projects;

namespace Read.Projects
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

        [EventProcessor("2ddde142-2195-40e4-a177-d17292df9b90")]
        public void Process(ProjectCreated @event)
        {
            var project = new Project
            {
                Id = @event.Id,
                NationalSociety = _nationalSocieties.GetById(@event.NationalSocietyId),
                DataOwner = _users.GetById(@event.DataOwnerId),
                Name = @event.Name,
                SurveillanceContext = (ProjectSurveillanceContext)@event.SurveillanceContext,
                HealthRisks = new ProjectHealthRisk[0],
                DataVerifiers = new User[0],
                SmsProxy = ""

            };
            _projects.Insert(project);
        }

        [EventProcessor("cb32f42e-5142-4e19-a4e0-04afd8bada9b")]
        public void Process(ProjectUpdated @event)
        {
            //TODO Use UpdateOne instead
            var project = _projects.GetById(@event.Id);
            project.NationalSociety = _nationalSocieties.GetById(@event.NationalSocietyId);
            project.DataOwner = _users.GetById(@event.DataOwnerId);
            project.Name = @event.Name;
            project.SurveillanceContext = (ProjectSurveillanceContext)@event.SurveillanceContext;
            project.SmsProxy = @event.SmsProxy;
            _projects.Update(p => p.Id == @event.Id, Builders<Project>.Update.Combine(
                Builders<Project>.Update.Set(p => p.NationalSociety, _nationalSocieties.GetById(@event.NationalSocietyId)),
                Builders<Project>.Update.Set(p => p.DataOwner, _users.GetById(@event.DataOwnerId)),
                Builders<Project>.Update.Set(p => p.Name, @event.Name),
                Builders<Project>.Update.Set(p => p.SurveillanceContext, (ProjectSurveillanceContext)@event.SurveillanceContext),
                Builders<Project>.Update.Set(p => p.SmsProxy, @event.SmsProxy))
            );
        }
        [EventProcessor("6db72e4b-cadc-43a7-b12f-ed9275a60ac1")]
        public void Process(ProjectDeleted @event)
        {
            _projects.Delete(p => p.Id == @event.ProjectId);
        }
        [EventProcessor("56aa04c3-b5bc-48ac-a45a-9f1efcadce62")]
        public void Process(ProjectHealthRiskAdded @event)
        {
            //TODO: Assumes that project exists. Should be verified in BusinessValidator
            _projects.Update(p => p.Id == @event.ProjectId,
                Builders<Project>.Update.AddToSet(p => p.HealthRisks, new ProjectHealthRisk
                {
                    HealthRiskId = @event.HealthRiskId,
                    Threshold = @event.Threshold
                }));
        }
        [EventProcessor("914923d5-21c5-43bf-956a-123218e4d8d1")]
        public void Process(ProjectHealthRiskThresholdUpdate @event)
        {

            //TODO: Assumes that project and health risk exists. Should be verified in BusinessValidator
            var projectHealthRisks = _projects.GetOne(p => p.Id == @event.ProjectId).HealthRisks;
            projectHealthRisks = projectHealthRisks.Select(r => r.HealthRiskId == @event.HealthRiskId
                    ? new ProjectHealthRisk
                    {
                        HealthRiskId = @event.HealthRiskId,
                        Threshold = @event.Threshold
                    }
                    : r
                ).ToArray();
            _projects.Update(p => p.Id == @event.ProjectId,
                Builders<Project>.Update.Set(p => p.HealthRisks, projectHealthRisks));

            var project = _projects.GetOne(p => p.Id == @event.ProjectId);
            var healthRisk = project.HealthRisks.FirstOrDefault(risk => risk.HealthRiskId == @event.HealthRiskId);
            _projectHealthRiskVersions.Append(project.Id, healthRisk, System.DateTimeOffset.UtcNow);
        }
        [EventProcessor("ea4b9ace-f4b1-4526-8e4b-601f6727a60f")]
        public void Process(DataVerifierAdded @event)
        {
            //TODO: Assumes that user and project exists. Should be verified in BusinessValidator
            var user = _users.GetById(@event.UserId);
            _projects.Update(p => p.Id == @event.ProjectId,
                Builders<Project>.Update.AddToSet(p => p.DataVerifiers, user));
        }
        [EventProcessor("15e22196-e233-468f-922c-8ac2b4eda660")]
        public void Process(DataVerifierRemoved @event)
        {
            //TODO: Assumes that project exists. Should be verified in BusinessValidator
            _projects.Update(p => p.Id == @event.ProjectId,
                Builders<Project>.Update.PullFilter(p => p.DataVerifiers, u => u.Id == @event.UserId));
        }
        [EventProcessor("fc262fe1-4aaf-497d-91ad-b9876e032f88")]
        public void Process(ReplyMessageConfigUpdated @event)
        {
            //TODO: Event should have Id field
            _replyMessages.Insert(new ReplyMessagesConfig
            {
                //FIXME! Event needs to look different!
                //Messages = @event.Messages
            });

        }
    }
    
}