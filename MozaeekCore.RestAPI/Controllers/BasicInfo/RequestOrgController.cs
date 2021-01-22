using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Facade.Query;

namespace MozaeekCore.RestAPI.Controllers.BasicInfo
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class RequestOrgController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IRequestOrgQueryFacade _requestOrgQueryFacade;

        public RequestOrgController(ICommandBus commandBus, IRequestOrgQueryFacade requestOrgQueryFacade)
        {
            this._commandBus = commandBus;
            _requestOrgQueryFacade = requestOrgQueryFacade;
        }
        
        [HttpGet]
        public Task<RequestOrgDto> GetById(long id)
        {
            return _requestOrgQueryFacade.GetRequestOrgById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestOrgCommand command)
        {
            var commandResult = await _commandBus.DispatchAsync<CreateRequestOrgCommand, CreateRequestOrgCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }
    }
}