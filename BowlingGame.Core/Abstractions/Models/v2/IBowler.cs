using BowlingGame.Core.Enums;

namespace BowlingGame.Core.Abstractions.Models.v2;
public interface IBowler
{
    int Id { get; set; }
    string Name { get; set; }
    BowlerRating Rating { get; set; }
}
