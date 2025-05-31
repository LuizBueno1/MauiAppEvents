using MauiAppEvents.Models;

namespace MauiAppEvents.Views;

public partial class PartyBooking : ContentPage
{
    public PartyBooking()
    {
        InitializeComponent();

        dtpck_start.MinimumDate = DateTime.Now;
        dtpck_start.MaximumDate = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day);

        dtpck_end.MinimumDate = dtpck_start.Date;
        dtpck_end.MaximumDate = dtpck_start.Date.AddMonths(3);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(entry_eventName.Text))
            {
                await DisplayAlert("Attention", "Please enter the event name.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(entry_location.Text))
            {
                await DisplayAlert("Attention", "Please enter the event location.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(entry_costPerParticipant.Text))
            {
                await DisplayAlert("Attention", "Please enter the cost per participant.", "OK");
                return;
            }

            PartyEvent partyEvent = new PartyEvent
            {
                EventName = entry_eventName.Text,
                StartDate = dtpck_start.Date,
                EndDate = dtpck_end.Date,
                NumberOfParticipants = Convert.ToInt32(stp_participants.Value),
                EventLocation = entry_location.Text,
                CostPerParticipant = Convert.ToDecimal(entry_costPerParticipant.Text)
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