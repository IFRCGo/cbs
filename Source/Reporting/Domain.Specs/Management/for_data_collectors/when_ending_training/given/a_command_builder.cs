/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Domain.Management.DataCollectors.Training;

namespace Domain.Specs.Management.for_data_collectors.when_ending_training.given
 {
     public class a_command_builder
     {
         public static EndTraining get_valid_command()
         {
             return  new EndTraining
             {
                DataCollectorId = Guid.NewGuid()
            };
         }

         public static EndTraining get_invalid_command(IEnumerable<Action<EndTraining>> invalidations)
         {
             var cmd = get_valid_command();
             foreach(var invalidate in invalidations)
             {
                 invalidate(cmd);
             }
             return cmd;
         }

         public static EndTraining get_invalid_command(Action<EndTraining> invalidate)
         {
             return get_invalid_command(new Action<EndTraining>[]{ invalidate });
         }
     }
}