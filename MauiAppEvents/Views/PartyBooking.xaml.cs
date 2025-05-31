using MauiAppEvents.Models;

namespace MauiAppEvents.Views;

public partial class PartyBooking : ContentPage
{
    App AppProperties;
    public PartyBooking()
    {
        InitializeComponent();

        AppProperties = (App)Application.Current;
        pck_package.ItemsSource = AppProperties.packages_list;

        dtpck_start.MinimumDate = DateTime.Now;
        dtpck_start.MaximumDate = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day);

        dtpck_end.MinimumDate = dtpck_start.Date;
        dtpck_end.MaximumDate = dtpck_start.Date.AddMonths(3);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pck_package.SelectedItem == null)
            {
                await DisplayAlert("Attention", "Please select a party package.", "OK");
                return;
            }

            if (stp_adults.Value == 0 && stp_children.Value == 0)
            {
                await DisplayAlert("Attention", "You must have at least 1 guest.", "OK");
                return;
            }

            PartyEvent partyEvent = new PartyEvent
            {
                SelectedPackage = (PartyPackage)pck_package.SelectedItem,
                AdultGuests = Convert.ToInt32(stp_adults.Value),
                ChildrenGuests = Convert.ToInt32(stp_children.Value),
                StartDate = dtpck_start.Date,
                EndDate = dtpck_end.Date
            };

            await Navigation.PushAsync(new PartyConfirmation()
            {
                BindingContext = partyEvent
            });

        }
        catch (Exception ex)
        {
            await DisplayAlert("Oops", ex.Message, "OK");
        }
    }

    private void dtpck_start_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker element = sender as DatePicker;
        DateTime start_selected_date = element.Date;

        dtpck_end.MinimumDate = start_selected_date;
        dtpck_end.MaximumDate = start_selected_date.AddMonths(3);
    }

    private void Btn_About_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new AboutPage());
        }
        catch (Exception ex)
        {
            DisplayAlert("Oops", ex.Message, "OK");
        }
    }
}