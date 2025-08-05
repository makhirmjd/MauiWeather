using System.Text.Json.Serialization;

namespace MauiWeather.Models;

public class Daily
{
    public string[] Time { get; set; } = [];
    [JsonPropertyName("weather_code")]
    public float[] WeatherCode { get; set; } = [];
    [JsonPropertyName("temperature_2m_max")]
    public float[] MaxTemperature { get; set; } = [];
    [JsonPropertyName("temperature_2m_min")]
    public float[] MinTemperature { get; set; } = [];

}

