using Concepts;
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
        private readonly IAutomaticReplies _automaticReplies;

        public AutomaticRepliesController(IDefaultAutomaticReplies defaultAutomaticReplies, IAutomaticReplies automaticReplies)
        {
            _defaultAutomaticReplies = defaultAutomaticReplies;
            _automaticReplies = automaticReplies;
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

        [HttpGet("{projectId}")]
        public async Task<IEnumerable<AutomaticReply>> GetAutomaticRepliesForProject(Guid projectId)
        {
            var projectDefined = await _automaticReplies.GetByProjectAsync(projectId);
            var defaults = await _defaultAutomaticReplies.GetAllAsync();

            return projectDefined.Select(c => new AutomaticReply()
            {
                IsDefault = false,
                Language = c.Language,
                Type = c.Type,
                Message = c.Message
            })
            .Union(defaults
                .Where(c => !projectDefined.Any(p => p.Type == c.Type && p.Language == c.Language))
                .Select(c => new AutomaticReply()
                {
                    IsDefault = true,
                    Language = c.Language,
                    Type = c.Type,
                    Message = c.Message
                })
            );
        }
    }
}
