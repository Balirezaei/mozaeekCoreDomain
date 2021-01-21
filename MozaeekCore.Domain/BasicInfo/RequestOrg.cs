using System.Collections.Generic;

namespace MozaeekCore.Domain.BasicInfo
{
    /// <summary>
    /// خواستگاه
    /// وزارت صنعت و معدن
    /// </summary>
    public class RequestOrg: IBasicInfo
    {
        public long Id { get;private set; }
        public string Title { get; private set; }
        public long? ParentId { get; private set; }
        public virtual RequestOrg Parent { get; private set; }
        public ICollection<RequestOrg> SubRequestOrgs { get; } = new List<RequestOrg>();

        public RequestOrg(string title, long? parentId)
        {
            Title = title;
            ParentId = parentId;
        }
    }
}