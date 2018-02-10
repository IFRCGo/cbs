/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Events;
using System;

namespace Events
{
    public class HealthRiskCreated : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ReadableId { get; set; }
        public int? Threshold { get; set; }
        public string ConfirmedCase { get; set; }
        public string Note { get; set; }
        public string SuspectedCase { get; set; }
        public string ProbableCase { get; set; }
        public string CommunityCase { get; set; }
        public string KeyMessage { get; set; }
    }
}
