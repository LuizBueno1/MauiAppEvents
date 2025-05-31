using MauiAppEvents.Models;

namespace MauiAppEvents
{
    public partial class App : Application
    {
        
        
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
