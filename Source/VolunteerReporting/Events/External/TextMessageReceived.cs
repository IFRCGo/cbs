/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Infrastructure.Events;
using System;

namespace Events.External
{
    public class TextMessageReceived : IEvent
    {
        public Guid Id { get; set; }
        public DateTimeOffset Sent { get; set; }
        public string OriginNumber { get; set; }
        public string Message { get; set; }
        public string Keyword { get; set; }
        public string ReceivedAtGatewayNumber { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
