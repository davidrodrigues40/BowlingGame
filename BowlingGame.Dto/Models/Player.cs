using BowlingGame.Abstractions.Models;

namespace BowlingGame.Dto.Models;

public record Player : IPlayer
{
    public string Name { get; set; } = string.Empty;
}
