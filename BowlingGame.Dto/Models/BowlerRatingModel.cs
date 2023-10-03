using BowlingGame.Abstractions.Models;
using System.Text.Json.Serialization;

namespace BowlingGame.Dto.Models;

public record BowlerRatingModel : IBowlerRating
{
    [JsonPropertyName("key")]
    public int Key { get; set; } = 0;

    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;
}
