using System.Text.Json.Serialization;

namespace MauiWeather.Models;

public class Current
{
    public string? Time { get; set; }
    public float Interval { get; set; }
    [JsonPropertyName("temperature_2m")]
    public float Temperature { get; set; }
    [JsonPropertyName("wind_speed_10m")]
    public float WindSpeed { get; set; }
    [JsonPropertyName("weather_code")]
    public float WeatherCode { get; set; }
}

