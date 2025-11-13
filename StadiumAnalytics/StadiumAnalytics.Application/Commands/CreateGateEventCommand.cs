using StadiumAnalytics.StadiumAnalytics.Domain.Enums;   

namespace StadiumAnalytics.StadiumAnalytics.Application.Commands
{
    public record CreateGateEventCommand
    (
        string Gate,
        DateTime Timestamp,
        int NumberOfPeople,
        EventType Type
    );
}
