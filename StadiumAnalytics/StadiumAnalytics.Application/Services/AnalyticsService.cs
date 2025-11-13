using StadiumAnalytics.StadiumAnalytics.Application.Queries;
using StadiumAnalytics.StadiumAnalytics.Application.Commands;
using StadiumAnalytics.StadiumAnalytics.Domain.DTOs;
using StadiumAnalytics.StadiumAnalytics.Domain.Repositories;

namespace StadiumAnalytics.StadiumAnalytics.Application.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IGateEventRepository _repo;
        public AnalyticsService(IGateEventRepository repo)
        {
            _repo = repo;
        }

        public async Task ProcessGateEventAsync(CreateGateEventCommand command)
        {
            var gateEvent = new Domain.Entities.GateEvent
            {
                GateName = command.Gate,
                Timestamp = command.Timestamp,
                NumberOfPeople = command.NumberOfPeople,
                Type = command.Type
            };

            await _repo.AddASync(gateEvent);
            await _repo.SaveChangesAsync();
        }


        public async Task<IEnumerable<AnalyticsResultDto>> GetAnalyticsAsync(GetAnalyticsQuery query)
        {
            return await _repo.GetAnalyticsAsync(
                query.Gate, 
                query.Type, 
                query.StartTime, 
                query.EndTime
            );
        }
    }
}
