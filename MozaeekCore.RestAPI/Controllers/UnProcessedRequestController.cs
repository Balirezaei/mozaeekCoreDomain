using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;

namespace MozaeekCore.RestAPI.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class UnProcessedRequestController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public UnProcessedRequestController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpGet]
        public string GetById(int id)
        {
            return id.ToString();
        }

        [HttpPost]
        public IActionResult Create(UnProcessedRequestCommand command)
        {
            var commandResult = _commandBus.Dispatch<UnProcessedRequestCommand, UnProcessedRequestCommandResult>(command);
            return Created(nameof(GetById), new { id = commandResult.Id });
        }

    }
}
