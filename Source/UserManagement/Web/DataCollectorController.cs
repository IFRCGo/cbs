using Domain;
using Events;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read;
using Read.DataCollectors;
using System;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web
{
    public class DataCollectorController : BaseController
    {
        readonly IDataCollectors _dataCollectors;

        public DataCollectorController(
            IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }

        [HttpGet("datacollectors")]
        public IEnumerable<DataCollector> GetAllDataCollectors()
        {
            Console.WriteLine("in datacollectors");
            var items = _dataCollectors.GetAllDataCollectors();
            return items;
        }

        [HttpPost("datacollector")]
        public void Add([FromBody] AddDataCollector command)
        {
            //TODO: This should be moved to domain project
            Apply(command.Id, new DataCollectorAdded
            {
                Id = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Age = command.Age,
                Sex = command.Sex,
                NationalSociety = command.NationalSociety,
                PreferredLanguage = command.PreferredLanguage,
                //MobilePhoneNumber = command.MobilePhoneNumber,
                //Email = command.Email
            });
        }
    }
}
