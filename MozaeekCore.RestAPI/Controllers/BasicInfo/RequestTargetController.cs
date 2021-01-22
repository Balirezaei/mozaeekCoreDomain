using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Facade.Query;

namespace MozaeekCore.RestAPI.Controllers.BasicInfo
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class RequestTargetController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IRequestTargetQueryFacade _requestTargetQueryFacade;

        public RequestTargetController(ICommandBus commandBus, IRequestTargetQueryFacade requestTargetQueryFacade)
        {
            this._commandBus = commandBus;
            _requestTargetQueryFacade = requestTargetQueryFacade;
        }


        [HttpGet]
        public  Task<RequestTargetDto> GetById(long id)
        {
            return _requestTargetQueryFacade.GetRequestTargetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestTargetCommand command)
        {
            var commandResult = await _commandBus.DispatchAsync<CreateRequestTargetCommand, CreateRequestTargetCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }
    }
}