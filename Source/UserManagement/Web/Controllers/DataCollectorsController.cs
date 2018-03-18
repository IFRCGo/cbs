using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using System;
using System.Threading.Tasks;
using Domain.DataCollector.Registering;
using Domain.DataCollector.Update;
using Domain.DataCollector;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : BaseController
    {
        private readonly IDataCollectors _dataCollectors;

        private readonly IDataCollectorCommandHandler _dataCollectorCommandHandler;

        public DataCollectorsController (
            IDataCollectorCommandHandler dataCollectorCommand,
            IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
            _dataCollectorCommandHandler = dataCollectorCommand;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _dataCollectors.GetAllAsync();
            return Ok(items);
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody] RegisterDataCollector command)
        {
            //Todo: We have to be clear whether we want Id to be supplied to a command by the controller or by the frontend
            //when registering a datacollector, or a staffuser for that matter
            command.DataCollectorId = Guid.NewGuid();
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateDataCollector command)
        {
            // TODO: Changes has to be made to updating the datacollector.
            // Should use the same system as staffusers
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }
    }
}
