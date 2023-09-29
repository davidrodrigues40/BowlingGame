using BowlingGame.Abstractions.Models;
using BowlingGame.Enums;

namespace BowlingGame.Models
{
    public class RatedBowler : Bowler, IRatedBowler
    {
        public Enums.BowlerRating Rating { get; set; }

        public RatedBowler(): base() { }
    }
}
