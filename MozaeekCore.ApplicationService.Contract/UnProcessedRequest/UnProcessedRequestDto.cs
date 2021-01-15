namespace MozaeekCore.ApplicationService.Contract
{
    public class UnProcessedRequestDto
    {
        public int Id { get;  set; }
        public string Title { get; set; }
        public string Summery { get; set; }
        public bool IsProcessed { get; set; }
    }
}