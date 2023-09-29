using BowlingGame.Abstractions.Models;

namespace BowlingGame.Dto.Models;

public record MenuItem : IMenuItem
{
    public string Value { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
}
