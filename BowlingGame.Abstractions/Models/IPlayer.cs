using BowlingGame.Core.Enums;

namespace BowlingGame.Abstractions.Models;

public interface IPlayer
{
    string Name { get; set; }
    BowlerRating Rating { get; set; }
}
