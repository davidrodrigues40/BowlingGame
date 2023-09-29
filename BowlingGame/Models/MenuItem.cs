using BowlingGame.Abstractions.Models;

namespace BowlingGame.Models;

public record MenuItem : IMenuItem
{
    public string Value { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
}
