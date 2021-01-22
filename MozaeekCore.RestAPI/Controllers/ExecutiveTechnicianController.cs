using Microsoft.AspNetCore.Mvc;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Facade.Query;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;

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
        public async Task<IActionResult> Create(CreateRegisterExecutiveTechnicianCommand command)
        {
            var commandResult = await commandBus.DispatchAsync<CreateRegisterExecutiveTechnicianCommand, RegisterExecutiveTechnicianCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }

    }
}
