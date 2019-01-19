/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts.HealthRisks;
using Concepts.Projects;
using Concepts.AutomaticReplies;
using Dolittle.ReadModels;

namespace Read.Reporting.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessage : IReadModel
    {
        public Guid Id { get; set; }
        public HealthRiskId HealthRiskId { get; set; }
        public ProjectId ProjectId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public AutomaticReplyKeyMessage(Guid id)
        {
            Id = id;
        } 
    }
}