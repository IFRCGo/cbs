/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.Projects;
using Concepts.HealthRisks;
using Concepts.AutomaticReplies;
using Dolittle.Commands;

namespace Domain.Reporting.AutomaticReplyMessages
{
    public class DefineAutomaticReplyKeyMessageForProject : ICommand
    {
        public HealthRiskId HealthRiskId { get; set; }
        public ProjectId ProjectId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
    }
}