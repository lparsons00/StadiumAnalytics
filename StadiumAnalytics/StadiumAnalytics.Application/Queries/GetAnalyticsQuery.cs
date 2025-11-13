namespace StadiumAnalytics.StadiumAnalytics.Application.Queries
{
    public record GetAnalyticsQuery
    (
        string? Gate = null, 
        string? Type = null,
        DateTime? StartTime = null, 
        DateTime? EndTime = null
    );
}
