using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class CreateRequestOrgCommand : Command
    {
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }

    public class CreateRequestOrgCommandResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }
}