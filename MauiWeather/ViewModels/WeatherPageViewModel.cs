using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MauiWeather.ViewModels;

public partial class WeatherPageViewModel : ObservableObject
{
    [RelayCommand]
    public async Task Search(string searchText)
    {
        Location? location = await GetCoordinatesAsync(searchText);
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
}
