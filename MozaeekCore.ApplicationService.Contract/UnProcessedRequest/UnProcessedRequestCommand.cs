using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class UnProcessedRequestCommand: Command
    {
        public string Title { get; set; }
        public string Summery { get; set; }
    }
}