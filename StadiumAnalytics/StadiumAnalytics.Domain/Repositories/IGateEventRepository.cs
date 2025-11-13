using StadiumAnalytics.StadiumAnalytics.Domain.Entities;    
using StadiumAnalytics.StadiumAnalytics.Domain.DTOs;

namespace StadiumAnalytics.StadiumAnalytics.Domain.Repositories
{
    public interface IGateEventRepository
    {
        Task AddASync(GateEvent gateEvent);
        Task<IEnumerable<AnalyticsResultDto>> GetAnalyticsAsync(string? gateName = null, string? eventType = null, DateTime? startTime = null, DateTime? endTime = null);
        Task<bool> SaveChangesAsync();
    }
}
