namespace BowlingGame.Core.Abstractions.Models;

public interface IFrame
{
    Dictionary<int, int> Roles { get; set; }
    int Score { get; set; }
}