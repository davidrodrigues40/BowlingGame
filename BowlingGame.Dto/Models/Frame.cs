using BowlingGame.Abstractions.Models;

namespace BowlingGame.Dto.Models;

public record Frame : IFrame
{
    public Dictionary<int, int> Roles { get; set; } = new();
    public int Score { get; set; } = 0;
}