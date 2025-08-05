using System.Text.Json.Serialization;

namespace MauiWeather.Models;

public class DailyData
{
    public string Time { get; set; } = default!;
    public float WeatherCode { get; set; }
    public float MaxTemperature { get; set; }
    public float MinTemperature { get; set; }
}
