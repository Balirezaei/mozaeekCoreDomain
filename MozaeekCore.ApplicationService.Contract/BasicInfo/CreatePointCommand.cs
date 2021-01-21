using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class CreatePointCommand : Command
    {
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }
    public class CreatePointCommandResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }
    
}