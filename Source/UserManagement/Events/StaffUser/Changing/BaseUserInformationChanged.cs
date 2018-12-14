/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

//using System;
//using Dolittle.Events;

//namespace Events.StaffUser.Changing
//{
//    public class AdminBaseUserInformationChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public string FullName { get; set; }
//        public string DisplayName { get; set; }
//        public string Email { get; set; }

//        public AdminBaseUserInformationChanged(Guid staffUserId, string fullName, string displayName, string email)
//        {
//            StaffUserId = staffUserId;
//            FullName = fullName;
//            DisplayName = displayName;
//            Email = email;
//        }
//    }

//    public class DataConsumerBaseUserInformationChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public string FullName { get; set; }
//        public string DisplayName { get; set; }
//        public string Email { get; set; }

//        public DataConsumerBaseUserInformationChanged(Guid staffUserId, string fullName, string displayName, string email)
//        {
//            StaffUserId = staffUserId;
//            FullName = fullName;
//            DisplayName = displayName;
//            Email = email;
//        }
//    }

//    public class DataCoordinatorBaseUserInformationChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public string FullName { get; set; }
//        public string DisplayName { get; set; }
//        public string Email { get; set; }

//        public DataCoordinatorBaseUserInformationChanged(Guid staffUserId, string fullName, string displayName, string email)
//        {
//            StaffUserId = staffUserId;
//            FullName = fullName;
//            DisplayName = displayName;
//            Email = email;
//        }
//    }

//    public class DataOwnerBaseUserInformationChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public string FullName { get; set; }
//        public string DisplayName { get; set; }
//        public string Email { get; set; }

//        public DataOwnerBaseUserInformationChanged(Guid staffUserId, string fullName, string displayName, string email)
//        {
//            StaffUserId = staffUserId;
//            FullName = fullName;
//            DisplayName = displayName;
//            Email = email;
//        }
//    }

//    public class DataVerifierBaseUserInformationChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public string FullName { get; set; }
//        public string DisplayName { get; set; }
//        public string Email { get; set; }

//        public DataVerifierBaseUserInformationChanged(Guid staffUserId, string fullName, string displayName, string email)
//        {
//            StaffUserId = staffUserId;
//            FullName = fullName;
//            DisplayName = displayName;
//            Email = email;
//        }
//    }

//    public class SystemConfiguratorBaseUserInformationChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public string FullName { get; set; }
//        public string DisplayName { get; set; }
//        public string Email { get; set; }

//        public SystemConfiguratorBaseUserInformationChanged(Guid staffUserId, string fullName, string displayName, string email)
//        {
//            StaffUserId = staffUserId;
//            FullName = fullName;
//            DisplayName = displayName;
//            Email = email;
//        }
//    }
//}