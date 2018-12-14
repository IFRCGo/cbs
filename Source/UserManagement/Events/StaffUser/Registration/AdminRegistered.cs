/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

// using System;
// using Dolittle.Events;

// namespace Events.StaffUser.Registration
// {
//     public class AdminRegistered : IEvent
//     {
//         public AdminRegistered(Guid staffUserId, string fullName, string displayName, 
//             string email, DateTimeOffset registeredAt)
//         {
//             StaffUserId = staffUserId;
//             FullName = fullName;
//             DisplayName = displayName;
//             Email = email;
//             RegisteredAt = registeredAt;
//         }

//         public Guid StaffUserId { get; set; }

//         public string FullName { get; set; }
//         public string DisplayName { get; set; }
//         public string Email { get; set; }
//         public DateTimeOffset RegisteredAt { get; set; }
//     }
// }