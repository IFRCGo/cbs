/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Domain.DataCollectors.PhoneNumber
{
    public interface IPhoneNumberRules
    {
         bool PhoneNumberIsRegistered(string number);
    }
}