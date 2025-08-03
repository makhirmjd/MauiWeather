using MauiWeather.ViewModels;
using MauiWeather.Views;

namespace MauiWeather
{
    public partial class App : Application
    {
        private readonly WeatherPageViewModel weatherPageViewModel;

        public App(WeatherPageViewModel weatherPageViewModel)
        {
            InitializeComponent();
            this.weatherPageViewModel = weatherPageViewModel;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new WeatherPageView(weatherPageViewModel));
        }
    }
}