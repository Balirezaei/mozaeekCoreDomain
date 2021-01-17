using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MozaeekCore.ApplicationService.Contract.ExecutiveTechs;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Facade.Query.ExecutiveTechs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MozaeekCore.RestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExecutiveTechnicianController : ControllerBase
    {
        private readonly ICommandBus commandBus;
        private readonly IExecutiveTechnicianQueryFacade executiveTechnicianQueryFacade;

        public ExecutiveTechnicianController(ICommandBus commandBus, IExecutiveTechnicianQueryFacade executiveTechnicianQueryFacade)
        {
            this.commandBus = commandBus;
            this.executiveTechnicianQueryFacade = executiveTechnicianQueryFacade;
        }
        [HttpGet("{id}")]
        public Task<ExecutiveTechnicianDto> GetById(int id)
        {
            return executiveTechnicianQueryFacade.GetExecutiveTechnicianById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterExecutiveTechnicianCommand command)
        {
            var commandResult = await commandBus.DispatchAsync<RegisterExecutiveTechnicianCommand, RegisterExecutiveTechnicianCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }

    }
}
