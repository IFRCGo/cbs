/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Project 
{
    public class ProjectCreated : IEvent 
    {
        
        public ProjectCreated (Guid id, string name, Guid nationalSocietyId, Guid dataOwnerId, int surveillanceContext) 
        {
            this.Id = id;
            this.Name = name;
            this.NationalSocietyId = nationalSocietyId;
            this.DataOwnerId = dataOwnerId;
            this.SurveillanceContext = surveillanceContext;

        }
        public Guid Id { get; }
        public string Name { get; }
        public Guid NationalSocietyId { get; }
        public Guid DataOwnerId { get; }

        public int SurveillanceContext { get; }
    }
}