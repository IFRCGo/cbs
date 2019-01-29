/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Domain.Management.DataCollectors.Registration;

namespace Domain.Specs.Management.for_data_collectors.when_deleting_a_datacollector.given
 {
     public class a_command_builder
     {
         public static DeleteDataCollector get_valid_command()
         {
             return  new DeleteDataCollector
             {
                DataCollectorId = Guid.NewGuid()
            };
         }

         public static DeleteDataCollector get_invalid_command(IEnumerable<Action<DeleteDataCollector>> invalidations)
         {
             var cmd = get_valid_command();
             foreach(var invalidate in invalidations)
             {
                 invalidate(cmd);
             }
             return cmd;
         }

         public static DeleteDataCollector get_invalid_command(Action<DeleteDataCollector> invalidate)
         {
             return get_invalid_command(new Action<DeleteDataCollector>[]{ invalidate });
         }
     }
}