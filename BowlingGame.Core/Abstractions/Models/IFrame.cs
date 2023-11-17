namespace BowlingGame.Core.Abstractions.Models;

public interface IFrame
{
    Dictionary<int, int> Rolls { get; set; }
    int Score { get; set; }
}