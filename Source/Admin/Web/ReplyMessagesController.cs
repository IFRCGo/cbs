/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Domain;
using Events;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public IEnumerable<ReplyMessage> GetAll()
        {
            return _replyMessages.GetAll();
        }

        [HttpGet("{messageId}")]
        public IEnumerable<ReplyMessage> GetById(Guid messsageId)
        {
            return _replyMessages.GetById(messsageId);
        }

        [HttpPost]
        public void Add([FromBody] CreateReplyMessage command)
        {
            Apply(command.Id, new ReplyMessageCreated
            {
                Message = command.Message,
                ReplyType = command.ReplyType
            });
        }

        [HttpPut("{messageId}")]
        public void Update(Guid messageId, [FromBody]UpdateMessage command)
        {
            Apply(command.Id, new MessageUpdated
            {
                Id = command.Id = messageId,
                Message = command.Message
            });

        }
    }
}