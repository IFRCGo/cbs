/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

//using System;
//using Dolittle.Events;

//namespace Events.StaffUser.Changing
//{
//    public class SystemConfiguratorBirthYearChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public int BirthYear { get; set; }

//        public SystemConfiguratorBirthYearChanged(Guid staffUserId, int birthYear)
//        {
//            StaffUserId = staffUserId;
//            BirthYear = birthYear;
//        }
//    }
//    public class DataCoordinatorBirthYearChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public int BirthYear { get; set; }

//        public DataCoordinatorBirthYearChanged(Guid staffUserId, int birthYear)
//        {
//            StaffUserId = staffUserId;
//            BirthYear = birthYear;
//        }
//    }
//    public class DataOwnerBirthYearChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public int BirthYear { get; set; }

//        public DataOwnerBirthYearChanged(Guid staffUserId, int birthYear)
//        {
//            StaffUserId = staffUserId;
//            BirthYear = birthYear;
//        }
//    }
//    public class DataVerifierBirthYearChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public int BirthYear { get; set; }

//        public DataVerifierBirthYearChanged(Guid staffUserId, int birthYear)
//        {
//            StaffUserId = staffUserId;
//            BirthYear = birthYear;
//        }
//    }
//}