using BowlingGame.Abstractions.Models;

namespace BowlingGame.Dto.Models;

public class Frame : IFrame
{
    public Dictionary<int, int> Roles { get; set; } = new();
    public int Score { get; set; } = 0;
}