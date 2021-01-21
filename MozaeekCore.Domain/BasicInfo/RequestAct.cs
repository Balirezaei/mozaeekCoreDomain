namespace MozaeekCore.Domain.BasicInfo
{
    /// <summary>
    /// کارواژه
    /// اخذ/تمدید/تعویض/
    /// </summary>
    public class RequestAct: IBasicInfo
    {
        public long Id { get;private set; }
        public string Title { get; private set; }

        public RequestAct(string title)
        {
            Title = title;
        }
    }
}