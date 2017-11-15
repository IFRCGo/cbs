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

        public AutomaticRepliesController(IDefaultAutomaticReplies defaultAutomaticReplies)
        {
            _defaultAutomaticReplies = defaultAutomaticReplies;
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
            var defaults = await _defaultAutomaticReplies.GetAllAsync();

            // TODO: Get replies for project and filter any custom from the default list

            return defaults.Select(c => new AutomaticReply() {
                IsDefault = true,
                Language = c.Language,
                Type = c.Type,
                Message = c.Message
            });
        }
    }
}
