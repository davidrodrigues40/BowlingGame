using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Dto.Models;

namespace BowlingGame.Files.Repository;
public class RatingRepository : BaseListFileRepository<BowlerRatingModel>, IRatingRepository, IFileRepository
{
    private readonly string _fileName = "ratings.json";
    public override string FileName => _fileName;

    public IEnumerable<IBowlerRating> GetRatings() => Get(_fileName);
}
