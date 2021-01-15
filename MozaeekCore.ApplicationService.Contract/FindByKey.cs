using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class FindByKey : Query
    {
        public FindByKey(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}