using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class CreateRequestActCommand : Command
    {
        public string Title { get; set; }
    }

    public class CreateRequestActCommandResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }


}