using BowlingGame.Abstractions.Models;
using BowlingGame.Enums;

namespace BowlingGame.Models
{
    public record RatedPlayer : Player, IRatedPlayer
    {
        public Enums.BowlerRating Rating { get; set; }
    }
}
