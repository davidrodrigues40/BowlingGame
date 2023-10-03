using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Repositories;
using BowlingGame.Dto.Models;

namespace BowlingGame.Files.Repository;
public class RatingRepository : BaseListFileRepository<BowlerRatingModel>, IRatingRepository
{
    private readonly string _fileName = "ratings.json";

    public IEnumerable<IBowlerRating> GetRatings() => Get(_fileName);
}
