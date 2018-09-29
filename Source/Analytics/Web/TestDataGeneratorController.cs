/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
using Events.VolunteerReporting.CaseReports;
using Infrastructure.AspNet;
using Infrastructure.Events;
using Infrastructure.Read.MongoDb;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Web {
    [Route ("api/testdatagenerator")]
    public class TestDataGeneratorController : Controller {
        readonly IEventReplayer _eventReplayer;

        public TestDataGeneratorController (
            IEventReplayer eventReplayer) {
            _eventReplayer = eventReplayer;
        }

        [HttpGet ("all")]
        public void CreateAll () {
            CreateCaseReports ();
        }

        [HttpGet ("case-reports")]
        public void CreateCaseReports () {
            var list = JsonConvert.DeserializeObject<CaseReportReceived[]> (
                System.IO.File.ReadAllText ("./TestData/CaseReports.json"));

            _eventReplayer.Replay (list, e => e.CaseReportId);
        }

    }
}