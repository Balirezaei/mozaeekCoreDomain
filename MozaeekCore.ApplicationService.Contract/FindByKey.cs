using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class FindByKey : Query
    {
        public FindByKey(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}