using Microsoft.EntityFrameworkCore;
using StadiumAnalytics.StadiumAnalytics.Domain.DTOs;
using StadiumAnalytics.StadiumAnalytics.Domain.Entities;
using StadiumAnalytics.StadiumAnalytics.Domain.Repositories;
using StadiumAnalytics.StadiumAnalytics.Infrastructure.Data;

namespace StadiumAnalytics.StadiumAnalytics.Infrastructure.Repositories
{
    public class GateEventRepository : IGateEventRepository
    {
        private readonly ApplicationDbContext _context;
        public GateEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddASync(GateEvent gateEvent)
        {
            await _context.GateEvents.AddAsync(gateEvent);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<AnalyticsResultDto>> GetAnalyticsAsync(string? gateName = null, string? eventType = null, DateTime? startTime = null, DateTime? endTime = null)
        {
            var query = _context.GateEvents.AsQueryable();

            //filters
            if (!string.IsNullOrEmpty(gateName))
            {
                query = query.Where(ge => ge.GateName == gateName);
            }

            if (!string.IsNullOrEmpty(eventType) && Enum.TryParse<Domain.Enums.EventType>(eventType, true, out var type))
            {
                query = query.Where(e => e.Type == type);
            }

            if (startTime.HasValue)
            {
                query = query.Where(e => e.Timestamp >= startTime.Value);
            }

            if (endTime.HasValue)
            {
                query = query.Where(e => e.Timestamp <= endTime.Value);
            }

            var results = await query.GroupBy(e => new { e.GateName, e.Type })
                .Select(g => new AnalyticsResultDto
                {
                    Gate = g.Key.GateName,
                    Type = g.Key.Type.ToString(),
                    NumberOfPeople = g.Sum(e => e.NumberOfPeople)
                })
                .ToListAsync();

            return results;
        }
    }
}
