/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Domain.Management.DataCollectors.Training;

namespace Domain.Specs.Management.for_data_collectors.when_beginning_training.given
 {
     public class a_command_builder
     {
         public static BeginTraining get_valid_command()
         {
             return  new BeginTraining
             {
                DataCollectorId = Guid.NewGuid()
            };
         }

         public static BeginTraining get_invalid_command(IEnumerable<Action<BeginTraining>> invalidations)
         {
             var cmd = get_valid_command();
             foreach(var invalidate in invalidations)
             {
                 invalidate(cmd);
             }
             return cmd;
         }

         public static BeginTraining get_invalid_command(Action<BeginTraining> invalidate)
         {
             return get_invalid_command(new Action<BeginTraining>[]{ invalidate });
         }
     }
}