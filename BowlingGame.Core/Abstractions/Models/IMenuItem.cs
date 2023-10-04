namespace BowlingGame.Core.Abstractions.Models;

public interface IMenuItem
{
    string Value { get; set; }
    string Route { get; set; }
}
