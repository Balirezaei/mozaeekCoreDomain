using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class CreateRequestTargetCommand : Command
    {
        public string Title { get; set; }
    }

    public class CreateRequestTargetCommandResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}