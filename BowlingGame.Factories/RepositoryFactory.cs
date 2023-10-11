using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;

namespace BowlingGame.Factories;
public class RepositoryFactory : IRepositoryFactory
{
    private readonly MenuRepository _menuProvider;
    private readonly RatingRepository _ratingProvider;

    public RepositoryFactory(MenuRepository menuProvider, RatingRepository ratingProvider)
    {
        _menuProvider = menuProvider;
        _ratingProvider = ratingProvider;
    }

    public IMenuRepository? CreateMenuRepository(DataSource datasource) => _menuProvider(datasource);
    public IRatingRepository? CreateRatingRepository(DataSource datasource) => _ratingProvider(datasource);
}
