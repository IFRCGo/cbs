/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.DataCollectors;
using Domain.Management.DataCollectors.EditInformation;
using Domain.Management.DataCollectors.Registration;

namespace Domain.Specs.Management.DataCollector.when_removing_a_phone_number.given
 {
     public class a_command_builder
     {
         public static RemovePhoneNumberFromDataCollector get_valid_command()
         {
             return new RemovePhoneNumberFromDataCollector
             {
                 DataCollectorId = Guid.Empty,
                 PhoneNumber = "11223344"
             };

         }

         public static RemovePhoneNumberFromDataCollector get_invalid_command(IEnumerable<Action<RemovePhoneNumberFromDataCollector>> invalidations)
         {
             var cmd = get_valid_command();
             foreach(var invalidate in invalidations)
             {
                 invalidate(cmd);
             }
             return cmd;
         }

         public static RemovePhoneNumberFromDataCollector get_invalid_command(Action<RemovePhoneNumberFromDataCollector> invalidate)
         {
             return get_invalid_command(new Action<RemovePhoneNumberFromDataCollector>[]{ invalidate });
         }
     }
 }