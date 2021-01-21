using System.Collections.Generic;

namespace MozaeekCore.Domain.BasicInfo
{
    /// <summary>
    ///برچسب
    /// تحصیلات/دانشگاهی/کارشناسی
    /// وضعیت شغلی/شاغل/آزاد
    /// </summary>
    public class Lable: IBasicInfo
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public long? ParentId { get; private set; }
        public virtual Lable Parent { get; private set; }
        public ICollection<Lable> SubLables { get; } = new List<Lable>();

        public Lable( string title, long? parentId)
        {
            Title = title;
            ParentId = parentId;
        }
    }
}