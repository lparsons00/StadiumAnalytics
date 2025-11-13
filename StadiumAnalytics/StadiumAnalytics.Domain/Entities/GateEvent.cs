using StadiumAnalytics.StadiumAnalytics.Domain.Enums;

namespace StadiumAnalytics.StadiumAnalytics.Domain.Entities
{
    public class GateEvent
    {
        public int Id { get; set; }
        public string GateName { get; set; }
        public DateTime Timestamp { get; set; }
        public int NumberOfPeople { get; set; }
        public EventType Type { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
