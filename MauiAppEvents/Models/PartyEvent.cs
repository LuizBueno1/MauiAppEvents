namespace MauiAppEvents.Models
{
    public class PartyEvent
    {
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfParticipants { get; set; }
        public string EventLocation { get; set; }
        public decimal CostPerParticipant { get; set; }

        public int EventDuration => (EndDate - StartDate).Days + 1;
        public decimal TotalValue => NumberOfParticipants * CostPerParticipant;
       
    }
}