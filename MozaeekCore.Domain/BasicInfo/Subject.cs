using System.Collections.Generic;

namespace MozaeekCore.Domain.BasicInfo
{
    /// <summary>
    ///زمینه
    /// کسب و کار/امور بازرگانی
    /// </summary>
    public class Subject: IBasicInfo
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public long? ParentId { get; private set; }
        public virtual Subject Parent { get; private set; }
        public ICollection<Subject> SubSubjects { get; } = new List<Subject>();

        public Subject(string title, long? parentId)
        {
            Title = title;
            ParentId = parentId;
        }
    }
}