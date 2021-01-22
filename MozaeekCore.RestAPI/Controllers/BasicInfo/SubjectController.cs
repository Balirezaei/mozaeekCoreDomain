using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Facade.Query;

namespace MozaeekCore.RestAPI.Controllers.BasicInfo
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly ISubjectQueryFacade _subjectQueryFacade;

        public SubjectController(ICommandBus commandBus, ISubjectQueryFacade subjectQueryFacade)
        {
            this._commandBus = commandBus;
            _subjectQueryFacade = subjectQueryFacade;
        }

        [HttpGet]
        public Task<SubjectDto> GetById(long id)
        {
            return _subjectQueryFacade.GetSubjectById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubjectCommand command)
        {
            var commandResult = await _commandBus.DispatchAsync<CreateSubjectCommand, CreateSubjectCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }
    }
}