using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiWeather.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MauiWeather.ViewModels;

public partial class WeatherPageViewModel : ObservableObject
{
    [ObservableProperty]
    public Weather? weather;

    [ObservableProperty]
    private string? placeName;

    [ObservableProperty]
    private DateTime date = DateTime.Now;

    [ObservableProperty]
    private bool isVisible;

    [ObservableProperty]
    private bool isLoading;

    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions options;


    public WeatherPageViewModel()
    {
        httpClient = new();
        options = new() { PropertyNameCaseInsensitive = true };
    }

    [RelayCommand]
    public async Task Search(string searchText)
    {
        PlaceName = searchText;
        Location? location = await GetCoordinatesAsync(searchText);
        if (location is not null)
        {
            await GetWeather(location);
        }
    }

    private async Task<Location?> GetCoordinatesAsync(string address)
    {
        IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(address) ?? [];
        Location? location = locations?.FirstOrDefault();

        if (location is not null)
        {
            Debug.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        }

        return location;
    }

    private async Task GetWeather(Location location)
    {
        IsLoading = true;
        string url = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&daily=weather_code,temperature_2m_max,temperature_2m_min&current=temperature_2m,wind_speed_10m,weather_code&timezone=auto";
        HttpResponseMessage response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            string? responseBody = await response.Content.ReadAsStringAsync();
            
            Weather = JsonSerializer.Deserialize<Weather>(responseBody, options);
            if (Weather is not null)
            {
                for (int i = 0; i < Weather.Daily!.Time.Length; i++)
                {
                    Weather.DailyDatas.Add(new()
                    {
                        Time = Weather.Daily!.Time[i],
                        WeatherCode = Weather.Daily!.WeatherCode[i],
                        MaxTemperature = Weather.Daily!.MaxTemperature[i],
                        MinTemperature = Weather.Daily!.MinTemperature[i],
                    });
                }
                IsVisible = true;
            }
        }
        IsLoading = false;
    }
}
