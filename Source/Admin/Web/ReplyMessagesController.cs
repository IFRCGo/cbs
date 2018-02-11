/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Domain;
using Events;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.AutomaticReplyMessages;

namespace Web
{
    [Route("api/replymessages")]
    public class ReplyMessagesController : BaseController
    {
        readonly IReplyMessages _replyMessages;

        public ReplyMessagesController(
            IReplyMessages replyMessages,
            ILogger<ProjectController> logger)
        {
            _replyMessages = replyMessages;
        }

        [HttpGet]
        public ReplyMessagesConfig Get()
        {
            return _replyMessages.Get();
        }

        [HttpPut]
        public IActionResult Update( [FromBody]UpdateReplyMessagesConfig command)
        {
            try
            {
                Apply(UpdateReplyMessagesConfig.Id, new ReplyMessageConfigUpdated
                {
                    Messages = command.Messages
                });
            }
            catch (DuplicateTagException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
 
}