using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace MauiWeather.Models;

public class Weather
{
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    [JsonPropertyName("generationtime_ms")]
    public float GenerationTime { get; set; }
    [JsonPropertyName("utc_offset_seconds")]
    public int UtcOffsetSeconds { get; set; }
    [JsonPropertyName("timezone")]
    public string? TimeZone { get; set; }
    [JsonPropertyName("timezone_abbreviation")]
    public string? TimeZoneAbbreviation { get; set; }
    public float Elevation { get; set; }
    [JsonPropertyName("current_units")]
    public CurrentUnits? CurrentUnits { get; set; }
    public Current? Current { get; set; }
    [JsonPropertyName("daily_units")]
    public DailyUnits? DailyUnits { get; set; }
    public Daily? Daily { get; set; }

    public ObservableCollection<DailyData> DailyDatas { get; set; } = [];
}

