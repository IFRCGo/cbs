/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Artifacts;
using Dolittle.Events;
using System;

namespace Events.External
{
    [Artifact("43c5c245-40ff-426d-a6f7-226427c142bb")]
    public class HealthRiskCreated : IEvent
    {
        public HealthRiskCreated(Guid id, int readableId, string name, string confirmedCase, string note, string suspectedCase, string probableCase, string communityCase, string keyMessage) 
        {
            this.Id = id;
            this.ReadableId = readableId;
            this.Name = name;
               
        }
        public Guid Id { get; set; }
        public int ReadableId { get; set; }
        public string Name { get; set; }
        //public int? Threshold { get; set; }
        //public string ConfirmedCase { get; set; }
        //public string Note { get; set; }
        //public string SuspectedCase { get; set; }
        //public string ProbableCase { get; set; }
        //public string CommunityCase { get; set; }
        //public string KeyMessage { get; set; }
    }
}
