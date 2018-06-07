/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Linq;
using Dolittle.Events.Processing;
using Events;
using Events.Admin;
using Events.Project;
using Events.ReplyMessage;
using MongoDB.Driver;
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
                SurveillanceContext = (ProjectSurveillanceContext)@event.SurveillanceContext
            };
            _projects.Insert(project);
        }

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

        public void Process(ProjectDeleted @event)
        {
            _projects.Delete(p => p.Id == @event.ProjectId);
        }

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

        public void Process(ProjectHealthRiskThresholdUpdate @event)
        {
            //TODO: Assumes that project and health risk exists. Should be verified in BusinessValidator
            _projects.Update(p => p.Id == @event.ProjectId,
                Builders<Project>.Update.Set(
                    p => p.HealthRisks.FirstOrDefault(risk => risk.HealthRiskId == @event.HealthRiskId)
                        .Threshold, @event.Threshold));

            var project = _projects.GetOne(p => p.Id == @event.ProjectId);
            var healthRisk = project.HealthRisks.FirstOrDefault(risk => risk.HealthRiskId == @event.HealthRiskId);
            _projectHealthRiskVersions.Append(project.Id, healthRisk, System.DateTimeOffset.UtcNow);
        }

        public void Process(DataVerifierAdded @event)
        {
            //TODO: Assumes that user and project exists. Should be verified in BusinessValidator
            var user = _users.GetById(@event.UserId);
            _projects.Update(p => p.Id == @event.ProjectId,
                Builders<Project>.Update.AddToSet(p => p.DataVerifiers, user));
        }

        public void Process(DataVerifierRemoved @event)
        {
            //TODO: Assumes that project exists. Should be verified in BusinessValidator
            _projects.Update(p => p.Id == @event.ProjectId,
                Builders<Project>.Update.PullFilter(p => p.DataVerifiers, u => u.Id == @event.UserId));
        }

        public void Process(ReplyMessageConfigUpdated @event)
        {
            //TODO: Event should have Id field
            _replyMessages.Insert(new ReplyMessagesConfig
            {
                Messages = @event.Messages
            });

        }
    }
    
}