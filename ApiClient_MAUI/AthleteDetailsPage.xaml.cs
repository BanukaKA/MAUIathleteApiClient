using ApiClient_MAUI.Models;

namespace ApiClient_MAUI;

public partial class AthleteDetailsPage : ContentPage
{
    private Athlete athlete;
    public AthleteDetailsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        athlete = (Athlete)this.BindingContext;

        string catagory;
        double bmi = BMIClassLibrary.BMI.bmiValue(Convert.ToDouble(athlete.Height)/100, Convert.ToDouble(athlete.Weight), out catagory);
        txtBMI.Text = bmi.ToString();
        txtBMIstatus.Text = catagory;

    }
}