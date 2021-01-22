using System.Collections.Generic;

namespace MozaeekCore.Domain.BasicInfo
{
    /// <summary>
    /// نقاط
    /// خراسان رضوی/کاشمر/ریوش
    /// </summary>
    public class Point: BasicInfo
    {
        public string Title { get; private set; }
        public long? ParentId { get; private set; }
        public virtual Point Parent { get; private set; }
        public ICollection<Point> SubPoints { get; } = new List<Point>();

        public Point(string title, long? parentId)
        {
            Title = title;
            ParentId = parentId;
        }
    }
}