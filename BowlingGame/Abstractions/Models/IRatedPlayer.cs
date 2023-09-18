using BowlingGame.Enums;

namespace BowlingGame.Abstractions.Models
{
    public interface IRatedPlayer : IPlayer
    {
        BowlerRating Rating { get; set; }
    }
}
