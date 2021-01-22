using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Facade.Query;

namespace MozaeekCore.RestAPI.Controllers.BasicInfo
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class LableController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly ILableQueryFacade _lableQueryFacade;

        public LableController(ICommandBus commandBus, ILableQueryFacade lableQueryFacade)
        {
            this._commandBus = commandBus;
            _lableQueryFacade = lableQueryFacade;
        }


        [HttpGet]
        public Task<LableDto> GetById(long id)
        {
            return _lableQueryFacade.GetLableById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLableCommand command)
        {
            var commandResult = await _commandBus.DispatchAsync<CreateLableCommand, CreateLableCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }
    }
}
