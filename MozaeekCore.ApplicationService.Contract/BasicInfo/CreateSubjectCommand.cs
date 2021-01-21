using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class CreateSubjectCommand : Command
    {
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }

    public class CreateSubjectCommandResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }
}