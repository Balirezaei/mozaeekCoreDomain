using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;

namespace MozaeekCore.RestAPI.Controllers.BasicInfo
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class LableController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public LableController(ICommandBus commandBus)
        {
            this._commandBus = commandBus;
        }


        [HttpGet]
        public async Task<int> GetById(int id)
        {
            return id;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLableCommand command)
        {
            var commandResult = await _commandBus.DispatchAsync<CreateLableCommand, CreateLableCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }
    }
}
