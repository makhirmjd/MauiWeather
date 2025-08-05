using System.Text.Json.Serialization;

namespace MauiWeather.Models;

public class DailyUnits
{
    public string? Time { get; set; }
    [JsonPropertyName("weather_code")]
    public string? WeatherCode { get; set; }
    [JsonPropertyName("temperature_2m_max")]
    public string? MaxTemperature { get; set; }
    [JsonPropertyName("temperature_2m_min")]
    public string? MinTemperature { get; set; }
}

