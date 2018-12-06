/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.HealthRisks
{
    public class HealthRiskModified : IEvent 
    {
        public Guid Id { get; }
        public string Name { get; }
        public int ReadableId { get; }
        public string CaseDefinition { get; }
        public string KeyMessage { get; }
        public string Note { get; }
        public string CommunityCase { get; }

        public HealthRiskModified (Guid id, string name, int readableId, string caseDefinition, string note, string communityCase, string keyMessage) 
        {
            Id = id;
            Name = name;
            ReadableId = readableId;
            CaseDefinition = caseDefinition;
            Note = note;
            CommunityCase = communityCase;
            KeyMessage = keyMessage;
        }
    }
}