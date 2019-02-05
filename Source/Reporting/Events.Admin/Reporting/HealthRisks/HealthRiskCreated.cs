/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Artifacts;
using Dolittle.Events;
using System;

namespace Events.Admin.Reporting.HealthRisks
{
    [Artifact("43c5c245-40ff-426d-a6f7-226427c142bb")]
    public class HealthRiskCreated : IEvent
    {
        public Guid Id { get; }
        public int ReadableId { get; }
        public string Name { get; }
        //public int? Threshold { get; }
        //public string ConfirmedCase { get; }
        //public string Note { get; }
        //public string SuspectedCase { get; }
        //public string ProbableCase { get; }
        //public string CommunityCase { get; }
        //public string KeyMessage { get; }

        public HealthRiskCreated(Guid id, int readableId, string name /*, string confirmedCase, string note, string suspectedCase, string probableCase, string communityCase, string keyMessage*/) 
        {
            Id = id;
            ReadableId = readableId;
            Name = name;               
        }
    }
}