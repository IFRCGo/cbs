/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Domain.DataCollectors.Registration;
using Concepts.DataCollector;

namespace Domain.Specs.DataCollectors.when_registering_a_data_collector.given
 {
     public class a_command_builder
     {
         public static RegisterDataCollector get_valid_command()
         {
             return  new RegisterDataCollector
             {
                 DataCollectorId = Guid.NewGuid(),
                 FullName = "Data Collector",
                 DisplayName = "Daty",
                 YearOfBirth = 1980,
                 Sex = Sex.Male,
                 PreferredLanguage = Language.English,
                 GpsLocation = new Location(123,123),
                 PhoneNumbers = new List<string>{"123456789"}
             };
         }

         public static RegisterDataCollector get_invalid_command(IEnumerable<Action<RegisterDataCollector>> invalidations)
         {
             var cmd = get_valid_command();
             foreach(var invalidate in invalidations)
             {
                 invalidate(cmd);
             }
             return cmd;
         }

         public static RegisterDataCollector get_invalid_command(Action<RegisterDataCollector> invalidate)
         {
             return get_invalid_command(new Action<RegisterDataCollector>[]{ invalidate });
         }
     }
 }

