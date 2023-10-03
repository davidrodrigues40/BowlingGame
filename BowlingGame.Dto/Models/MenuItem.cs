using BowlingGame.Abstractions.Models;
using System.Text.Json.Serialization;

namespace BowlingGame.Dto.Models;

public record MenuItem : IMenuItem
{
    [JsonPropertyName("key")]
    public string Value { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public string Route { get; set; } = string.Empty;
}
