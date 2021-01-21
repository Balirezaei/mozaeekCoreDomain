using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;

namespace MozaeekCore.RestAPI.Controllers.BasicInfo
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public PointController(ICommandBus commandBus)
        {
            this._commandBus = commandBus;
        }


        [HttpGet]
        public async Task<int> GetById(int id)
        {
            return id;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePointCommand command)
        {
            var commandResult = await _commandBus.DispatchAsync<CreatePointCommand, CreatePointCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }
    }
}