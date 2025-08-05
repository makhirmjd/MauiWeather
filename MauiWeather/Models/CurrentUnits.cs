using System.Text.Json.Serialization;

namespace MauiWeather.Models;

public class CurrentUnits
{
    public string? Time { get; set; }
    public string? Interval { get; set; }
    [JsonPropertyName("temperature_2m")]
    public string? Temperature { get; set; }
    [JsonPropertyName("wind_speed_10m")]
    public string? WindSpeed { get; set; }
    [JsonPropertyName("weather_code")]
    public string? WeatherCode { get; set; }
}

