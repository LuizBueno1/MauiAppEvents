namespace MauiAppEvents.Models
{
    internal class PartyEvent
    {
        public PartyPackage SelectedPackage { get; set; }
        public int AdultGuests { get; set; }
        public int ChildrenGuests { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EventDuration
        {
            get => EndDate.Subtract(StartDate).Days + 1;
        }

        public double TotalValue
        {
            get
            {
                double adults_value = AdultGuests * SelectedPackage.AdultPrice;
                double children_value = ChildrenGuests * SelectedPackage.ChildPrice;
                double total = (adults_value + children_value) * EventDuration;
                return total;
            }
        }

        public int TotalGuests => AdultGuests + ChildrenGuests;
    
    }
}
