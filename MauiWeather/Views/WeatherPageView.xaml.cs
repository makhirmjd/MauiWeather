using MauiWeather.ViewModels;

namespace MauiWeather.Views;

public partial class WeatherPageView : ContentPage
{
    private readonly WeatherPageViewModel weatherPageViewModel;

    public WeatherPageView(WeatherPageViewModel weatherPageViewModel)
	{
		InitializeComponent();
        this.weatherPageViewModel = weatherPageViewModel;
        BindingContext = weatherPageViewModel;
    }
}