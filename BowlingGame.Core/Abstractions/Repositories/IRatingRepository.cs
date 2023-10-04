using BowlingGame.Core.Abstractions.Models;

namespace BowlingGame.Core.Abstractions.Repositories;
public interface IRatingRepository
{
    IEnumerable<IBowlerRating> GetRatings();
}
