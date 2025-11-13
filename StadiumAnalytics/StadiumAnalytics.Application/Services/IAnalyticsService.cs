using StadiumAnalytics.StadiumAnalytics.Application.Commands;
using StadiumAnalytics.StadiumAnalytics.Application.Queries;
using StadiumAnalytics.StadiumAnalytics.Domain.DTOs;

namespace StadiumAnalytics.StadiumAnalytics.Application.Services
{
    public interface IAnalyticsService
    {
        Task ProcessGateEventAsync(CreateGateEventCommand command);
        Task<IEnumerable<AnalyticsResultDto>> GetAnalyticsAsync(GetAnalyticsQuery query);
    }
}
