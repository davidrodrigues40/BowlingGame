using BowlingGame.Abstractions.Models;
using BowlingGame.Core.Enums;

namespace BowlingGame.Dto.Models;

public class RatedBowler : Bowler, IRatedBowler
{
    public BowlerRating Rating { get; set; }

    public RatedBowler() : base() { }
}
