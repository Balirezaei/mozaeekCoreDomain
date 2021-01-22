using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Facade.Query;

namespace MozaeekCore.RestAPI.Controllers.BasicInfo
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IPointQueryFacade _pointQueryFacade;

        public PointController(ICommandBus commandBus, IPointQueryFacade pointQueryFacade)
        {
            _commandBus = commandBus;
            _pointQueryFacade = pointQueryFacade;
        }

        [HttpGet]
        public Task<PointDto> GetById(long id)
        {
            return _pointQueryFacade.GetPointById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePointCommand command)
        {
            var commandResult = await _commandBus.DispatchAsync<CreatePointCommand, CreatePointCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }
    }
}