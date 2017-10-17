/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace Read.TextMessageRecievedFeatures
{
    public interface IReceivedTextMessages
    {
        ReceivedTextMessage GetById(Guid id);
        IEnumerable<ReceivedTextMessage> ListByPhonenumber(PhoneNumber phoneNumber);
        void Save(ReceivedTextMessage receivedTextMessage);
    }
}