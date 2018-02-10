using Concepts;
using doLittle.Domain;
using Domain;
using Events;
using Events.External;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.AutomaticReplyMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/automaticreplies")]
    public class AutomaticRepliesController : BaseController
    {
        private readonly IDefaultAutomaticReplies _defaultAutomaticReplies;
        private readonly IDefaultAutomaticReplyKeyMessages _defaultAutomaticReplyKeyMessages;
        private readonly IAutomaticReplies _automaticReplies;
        private readonly IAutomaticReplyKeyMessages _automaticReplyKeyMessages;
        private readonly IAggregateRootRepositoryFor<AutomaticReplyDefinition> _automaticReplyRepository;

        public AutomaticRepliesController(
            IDefaultAutomaticReplies defaultAutomaticReplies,
            IDefaultAutomaticReplyKeyMessages defaultAutomaticReplyKeyMessages,
            IAutomaticReplies automaticReplies,
            IAutomaticReplyKeyMessages automaticReplyKeyMessages,
            IAggregateRootRepositoryFor<AutomaticReplyDefinition> automaticReplyRepository
            )
        {
            _defaultAutomaticReplies = defaultAutomaticReplies;
            _defaultAutomaticReplyKeyMessages = defaultAutomaticReplyKeyMessages;
            _automaticReplies = automaticReplies;
            _automaticReplyKeyMessages = automaticReplyKeyMessages;
            _automaticReplyRepository = automaticReplyRepository;
        }

        [HttpGet("automaticreplytypes")]
        public IEnumerable<AutomaticReplyTypeName> GetAutomaticReplyTypes()
        {
            return Enum.GetValues(typeof(AutomaticReplyType)).Cast<AutomaticReplyType>().Select(c => new AutomaticReplyTypeName()
            {
                Id = (int)c,
                Name = c.ToString()
            });
        }

        [k("{projectId}")]
        public async Task<IEnumerable<Models.AutomaticReply>> GetAutomaticRepliesForProject(Guid projectId)
        {
            var projectDefined = await _automaticReplies.GetByProjectAsync(projectId);
            var defaults = await _defaultAutomaticReplies.GetAllAsync();

            return projectDefined.Select(c => new Web.Models.AutomaticReply()
            {
                IsDefault = false,
                Language = c.Language,
                Type = c.Type,
                Message = c.Message
            })
            .Union(defaults
                .Where(c => !projectDefined.Any(p => p.Type == c.Type && p.Language == c.Language))
                .Select(c => new Web.Models.AutomaticReply()
                {
                    IsDefault = true,
                    Language = c.Language,
                    Type = c.Type,
                    Message = c.Message
                })
            );
        }

        [HttpGet("keymessages/{projectId}")]
        public async Task<IEnumerable<Web.Models.AutomaticReplyKeyMessage>> GetAutomaticReplyKeyMessagesForProject(Guid projectId)
        {
            var projectDefined = await _automaticReplyKeyMessages.GetByProjectAsync(projectId);
            var defaults = await _defaultAutomaticReplyKeyMessages.GetAllAsync();

            return projectDefined.Select(c => new Web.Models.AutomaticReplyKeyMessage()
            {
                HealthRiskId = c.HealthRiskId, 
                IsDefault = false,
                Language = c.Language,
                Type = c.Type,
                Message = c.Message
            })
            .Union(defaults
                .Where(c => !projectDefined.Any(p => p.Type == c.Type && p.Language == c.Language))
                .Select(c => new Web.Models.AutomaticReplyKeyMessage()
                {
                    HealthRiskId = c.HealthRiskId,
                    IsDefault = true,
                    Language = c.Language,
                    Type = c.Type,
                    Message = c.Message
                })
            );
        }

        [HttpPut]
        public IActionResult CreateOrUpdateAutomaticReply([FromBody]DefineAutomaticReplyForProject automaticReply)
        {
            var eventId = Guid.NewGuid();
            var repository = _automaticReplyRepository.Get(eventId);
            repository.Define(
                automaticReply.ProjectId,
                automaticReply.Type,
                automaticReply.Language,
                automaticReply.Message
                );
            return Ok();
        }

        [HttpPut("keymessage")]
        public IActionResult CreateOrUpdateAutomaticReplyKeyMessage([FromBody]DefineAutomaticReplyKeyMessageForProject automaticReplyKeyMessage)
        {
            var eventId = Guid.NewGuid();
            var repository = _automaticReplyRepository.Get(eventId);
            repository.DefineKeyMessage(
                automaticReplyKeyMessage.HealthRiskId,
                automaticReplyKeyMessage.ProjectId,
                automaticReplyKeyMessage.Type,
                automaticReplyKeyMessage.Language,
                automaticReplyKeyMessage.Message
                );
            return Ok();
        }
    }
}
