using ApiClient_MAUI.Data;
using ApiClient_MAUI.Models;
using ApiClient_MAUI.Utilities;
using System.Text;

namespace ApiClient_MAUI;

public partial class MainPage : ContentPage
{
    private List<Sport> sports;
    private List<Athlete> athletes;

    public MainPage()
	{
		InitializeComponent();
        sports = new List<Sport> { new Sport {ID = 0, Name = "All Sports"} };
        athletes = new List<Athlete>();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await ShowSports();
	}

    private async Task ShowSports()
    {
        //GetSports
        SportRepository sp = new SportRepository();
        try
        {
            List<Sport> dbSports = await sp.GetSports();
            foreach(Sport s in dbSports.OrderBy(s => s.Name))
            {
                sports.Add(s);
            }
            ddlSports.ItemsSource = sports;
            ddlSports.SelectedIndex = 0;
        }
        catch (ApiException apiEx)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Errors:");
            foreach(var error in apiEx.Errors)
            {
                sb.AppendLine("-" + error);
            }
            await DisplayAlert("Problem Getting a List of Sports", sb.ToString(), "Ok");
        }
        catch (Exception ex)
        {
            if(ex.InnerException != null)
            {
                if (ex.GetBaseException().Message.Contains("connection with the server"))
                {
                    await DisplayAlert("Error", "No connection with the server. Check if the web Service is running.", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "If the problem persisits Contact the Administraitor.", "Ok");
                }
            }
            else
            {
                if (ex.Message.Contains("NameResolutionFailure"))
                {
                    await DisplayAlert("Internet Access Error", "Cannot resolve the Uri: " + Jeeves.DBUri.ToString() , "Ok");
                }
                else
                {
                    await DisplayAlert("General Error", ex.Message, "Ok");
                }
            }
            
        }
    }

    private async void ddlSports_SelectedIndexChanged(object sender, EventArgs e)
	{
        Sport selSport = (Sport)ddlSports.SelectedItem;
        await ShowAthletes(selSport?.ID);
	}

    private async Task ShowAthletes(int? SportID)
    {
        Loading.IsRunning = true;
        AthleteRepository a = new AthleteRepository();
        try
        {
            if(SportID.GetValueOrDefault() > 0)
            {
                athletes = await a.GetAthletesByLeague(SportID.GetValueOrDefault());
            }
            else
            {
                athletes = await a.GetAthletes();
            }
            athleteList.ItemsSource = athletes;
        }
        catch (ApiException apiEx)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Errors:");
            foreach (var error in apiEx.Errors)
            {
                sb.AppendLine("-" + error);
            }
            await DisplayAlert("Problem Getting a List of Sports", sb.ToString(), "Ok");
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                if (ex.GetBaseException().Message.Contains("connection with the server"))
                {
                    await DisplayAlert("Error", "No connection with the server. Check if the web Service is running.", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "If the problem persisits Contact the Administraitor.", "Ok");
                }
            }
            else
            {
                if (ex.Message.Contains("NameResolutionFailure"))
                {
                    await DisplayAlert("Internet Access Error", "Cannot resolve the Uri: " + Jeeves.DBUri.ToString(), "Ok");
                }
                else
                {
                    await DisplayAlert("General Error", ex.Message, "Ok");
                }
            }

        }
        finally
        {
            Loading.IsRunning = false;
        }
    }

    private async void AthleteSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(e.SelectedItem != null)
        {
            var athlete = (Athlete)e.SelectedItem;
            var athleteDetailPage = new AthleteDetailsPage();
            athleteDetailPage.BindingContext = athlete;
            await Navigation.PushAsync(athleteDetailPage);
        }
    }
}

