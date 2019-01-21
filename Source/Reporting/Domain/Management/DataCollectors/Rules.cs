/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;

namespace Domain.Management.DataCollectors
{
    public delegate bool PhoneNumberShouldNotBeRegistered(string number);
    public delegate bool PhoneNumberShouldBeRegistered(string number);
    public delegate bool MustExist(DataCollectorId dataCollector);
    public delegate bool MustBeAllowedToChangeDisplayName(DataCollectorId dataCollector, string displayName);
    public delegate bool DisplayNameMustBeUnique(string displayName);
    public delegate bool CantExist(DataCollectorId dataCollector);
}