/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

// using System;
// using Dolittle.Events;

// namespace Events.StaffUser
// {

//     public class NationalSocietyAssignedToSystemConfigurator : IEvent
//     {
//         public Guid StaffUserId { get; set; }
//         public Guid NationalSociety { get; set; }

//         public NationalSocietyAssignedToSystemConfigurator(Guid staffUserId, Guid nationalSociety)
//         {
//             StaffUserId = staffUserId;
//             NationalSociety = nationalSociety;
//         }
//     }

//     public class NationalSocietyAssignedToDataCoordinator : IEvent
//     {
//         public Guid StaffUserId { get; set; }
//         public Guid NationalSociety { get; set; }

//         public NationalSocietyAssignedToDataCoordinator(Guid staffUserId, Guid nationalSociety)
//         {
//             StaffUserId = staffUserId;
//             NationalSociety = nationalSociety;
//         }
//     }
// }