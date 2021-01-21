using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class CreateLableCommand : Command
    {
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }

    public class CreateLableCommandResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }



}