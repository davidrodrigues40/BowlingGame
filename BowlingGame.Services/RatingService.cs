using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Dto.Models;

namespace BowlingGame.Services;

public class RatingService : IRatingService
{
    public IEnumerable<IBowlerRating> GetRatings()
    {
        foreach (int key in Enum.GetValues(typeof(BowlerRating)))
        {
            string? name = Enum.GetName(typeof(BowlerRating), key);
            if (name is null)
            {
                continue;
            }

            yield return new BowlerRatingModel
            {
                Value = name,
                Key = key
            };
        }
    }
}
