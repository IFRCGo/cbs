/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

/*

using System.Linq;
using Domain;
using Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.AutomaticReplyMessages;

namespace Web
{
    [Route("api/replymessages")]
    public class ReplyMessagesController : Controller
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
            return _replyMessages.GetMany(_ => true).FirstOrDefault();
        }

        //TODO: Integrate to DoLittle2.0
        //[HttpPut]
        //public IActionResult Update( [FromBody]UpdateReplyMessagesConfig command)
        //{
        //    try
        //    {
        //        Apply(UpdateReplyMessagesConfig.Id, new ReplyMessageConfigUpdated
        //        {
        //            Messages = command.Messages
        //        });
        //    }
        //    catch (DuplicateTagException e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    return Ok();
        //}
    }
 
}*/