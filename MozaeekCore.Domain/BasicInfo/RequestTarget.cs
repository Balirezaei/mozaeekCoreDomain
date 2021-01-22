namespace MozaeekCore.Domain.BasicInfo
{
    /// <summary>
    /// کارمراد
    /// کارت ملی/کارت بازرگانی/گواهینامه
    /// </summary>
    public class RequestTarget : BasicInfo
    {
        public string Title { get; private set; }

        public RequestTarget(string title)
        {
            Title = title;
        }
    }
}