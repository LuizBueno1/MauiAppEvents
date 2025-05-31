using MauiAppEvents.Models;

namespace MauiAppEvents
{
    public partial class App : Application
    {
        public List<PartyPackage> packages_list = new List<PartyPackage>
        {
            new PartyPackage()
            {
                Description = "Premium Celebration Package",
                AdultPrice = 85.0,
                ChildPrice = 45.0
            },
            new PartyPackage()
            {
                Description = "Deluxe Party Package",
                AdultPrice = 65.0,
                ChildPrice = 35.0
            },
            new PartyPackage()
            {
                Description = "Standard Celebration",
                AdultPrice = 45.0,
                ChildPrice = 25.0
            },
            new PartyPackage()
            {
                Description = "Basic Party Package",
                AdultPrice = 25.0,
                ChildPrice = 15.0
            }
        };
        
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.PartyBooking());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 700;
            return window;
        }
    }
}
