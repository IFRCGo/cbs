/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

//using System;
//using System.IO;
//using Dolittle.Commands.Coordination;
//using Domain.DataCollectors;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Web.TestData;

//namespace Web.Controllers
//{
//    [Route("api/testdatagenerator")]
//    public class TestDataGeneratorController : Controller
//    {
//        private readonly ICommandCoordinator _commandCoordinator;

//        private readonly IDataCollectors _dataCollectors;

//        public TestDataGeneratorController(
//            ICommandCoordinator commandCoordinator,
//            IDataCollectors dataCollectors
//        )
//        {
//            _commandCoordinator = commandCoordinator;
//            _dataCollectors = dataCollectors;
//        }

//        [HttpGet("generatetestdataset")]
//        public void GenerateTestDataSet()
//        {
//            TestDataGenerator.GenerateAllTestData();
//        }

//        [HttpGet("all")]
//        public void CreateAll()
//        {
//            CreateDataCollectorCommands();
//        }

//        [HttpGet("datacollectorcommands")]
//        public void CreateDataCollectorCommands()
//        {
//            DeleteDataCollectors();
//            RegisterDataCollector[] commands;
//            try
//            {
//                commands = JsonConvert.DeserializeObject<RegisterDataCollector[]>(
//                    System.IO.File.ReadAllText("./TestData/DataCollectors.json"));
//            }
//            catch (FileNotFoundException)
//            {
//                TestDataGenerator.GenerateCorrectRegisterDataCollectorCommands();
//                commands = JsonConvert.DeserializeObject<RegisterDataCollector[]>(
//                    System.IO.File.ReadAllText("./TestData/DataCollectors.json"));
//            }

//            foreach (var cmd in commands)
//            {
//                cmd.DataCollectorId = Guid.NewGuid();
//                var result = _commandCoordinator.Handle(cmd);
//            }
//        }

//        [HttpGet("deleteall")]
//        public void DeleteAll()
//        {
//            DeleteDataCollectors();
//        }

//        [HttpGet("deletedatacollectorcollection")]
//        public void DeleteDataCollectors()
//        {
//            _dataCollectors.Delete(_ => true);
//        }
//    }
//}