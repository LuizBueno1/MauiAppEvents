namespace MauiAppEvents.Views;

public partial class PartyConfirmation : ContentPage
{
	public PartyConfirmation()
	{
		InitializeComponent();
	}

    private async void Button_Back_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Oops", ex.Message, "OK");
        }
    }

    private async void Button_NewParty_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Oops", ex.Message, "OK");
        }
    }
}