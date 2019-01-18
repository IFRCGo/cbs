/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts;
using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.Management.DataCollectors.EditInformation
{
    public class ChangePreferredLanguage : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public Language PreferredLanguage { get; set; }
    }
}