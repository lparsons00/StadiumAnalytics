namespace StadiumAnalytics.StadiumAnalytics.Domain.DTOs
{
    public class AnalyticsResultDto
    {
        public string Gate { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int NumberOfPeople { get; set; }
    }
}
