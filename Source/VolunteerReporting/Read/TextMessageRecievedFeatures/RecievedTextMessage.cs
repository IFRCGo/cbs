/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Read.TextMessageRecievedFeatures
{
    public class RecievedTextMessage
    {
        public RecievedTextMessage()
        {
            
        }

        public RecievedTextMessage(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public DateTimeOffset Sent { get; set; }
        public string OriginNumber { get; set; }
        public string Message { get; set; }
        public string Keyword { get; set; }
        public string ReceivedAtGatewayNumber { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
