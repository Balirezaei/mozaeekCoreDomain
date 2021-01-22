using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Facade.Query;

namespace MozaeekCore.RestAPI.Controllers.BasicInfo
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class RequestActController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IRequestActQueryFacade _requestActQueryFacade;

        public RequestActController(ICommandBus commandBus, IRequestActQueryFacade requestActQueryFacade)
        {
            this._commandBus = commandBus;
            _requestActQueryFacade = requestActQueryFacade;
        }
        
        [HttpGet]
        public Task<RequestActDto> GetById(long id)
        {
            return _requestActQueryFacade.GetRequestActById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestActCommand command)
        {
            var commandResult = await _commandBus.DispatchAsync<CreateRequestActCommand, CreateRequestActCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }
    }
}