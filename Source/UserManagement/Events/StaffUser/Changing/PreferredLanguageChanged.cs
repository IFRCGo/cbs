/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

//using System;
//using Dolittle.Events;

//namespace Events.StaffUser.Changing
//{
//    public class SystemConfiguratorPreferredLanguageChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public int Language { get; set; }

//        public SystemConfiguratorPreferredLanguageChanged(Guid staffUserId, int language)
//        {
//            StaffUserId = staffUserId;
//            Language = language;
//        }
//    }

//    public class DataCoordinatorPreferredLanguageChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public int Language { get; set; }

//        public DataCoordinatorPreferredLanguageChanged(Guid staffUserId, int language)
//        {
//            StaffUserId = staffUserId;
//            Language = language;
//        }
//    }

//    public class DataOwnerPreferredLanguageChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public int Language { get; set; }

//        public DataOwnerPreferredLanguageChanged(Guid staffUserId, int language)
//        {
//            StaffUserId = staffUserId;
//            Language = language;
//        }
//    }

//    public class DataVerifierPreferredLanguageChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public int Language { get; set; }

//        public DataVerifierPreferredLanguageChanged(Guid staffUserId, int language)
//        {
//            StaffUserId = staffUserId;
//            Language = language;
//        }
//    }
//}