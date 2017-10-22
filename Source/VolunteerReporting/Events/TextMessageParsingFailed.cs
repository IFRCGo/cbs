/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Infrastructure.Events;

namespace Events
{
    public class TextMessageParsingFailed : IEvent
    {
        public Guid Id { get; set; }
        public Guid TextMessageId { get; set; }
        public Guid DataCollectorId { get; set; }
        public string Message { get; set; }
        public string ParsingErrorMessage { get; set; }
    }
}