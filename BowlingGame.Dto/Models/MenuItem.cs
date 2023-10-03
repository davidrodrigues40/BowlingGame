using BowlingGame.Abstractions.Models;
using System.Text.Json.Serialization;

namespace BowlingGame.Dto.Models;

public record MenuItem : IMenuItem
{
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    [JsonPropertyName("route")]
    public string Route { get; set; } = string.Empty;
}
