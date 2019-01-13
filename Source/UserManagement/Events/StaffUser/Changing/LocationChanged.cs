/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

//using System;
//using Dolittle.Events;

//namespace Events.StaffUser.Changing
//{
//    public class DataVerifierLocationChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public double LocationLatitude { get; set; }
//        public double LocationLongitude { get; set; }

//        public DataVerifierLocationChanged(Guid staffUserId, double locationLatitude, double locationLongitude)
//        {
//            StaffUserId = staffUserId;
//            LocationLatitude = locationLatitude;
//            LocationLongitude = locationLongitude;
//        }
//    }

//    public class DataConsumerLocationChanged : IEvent
//    {
//        public Guid StaffUserId { get; set; }
//        public double LocationLatitude { get; set; }
//        public double LocationLongitude { get; set; }

//        public DataConsumerLocationChanged(Guid staffUserId, double locationLatitude, double locationLongitude)
//        {
//            StaffUserId = staffUserId;
//            LocationLatitude = locationLatitude;
//            LocationLongitude = locationLongitude;
//        }
//    }
//}