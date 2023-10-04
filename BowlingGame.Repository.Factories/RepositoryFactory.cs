using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;

namespace BowlingGame.Repository.Factories;
public class RepositoryFactory : IRepositoryFactory
{
    private readonly MenuRepositoryProvider _menuProvider;
    private readonly RatingRepositoryProvider _ratingProvider;

    public RepositoryFactory(MenuRepositoryProvider menuProvider, RatingRepositoryProvider ratingProvider)
    {
        _menuProvider = menuProvider;
        _ratingProvider = ratingProvider;
    }

    public IMenuRepository? CreateMenuRepository(DataSource datasource) => _menuProvider(datasource);
    public IRatingRepository? CreateRatingRepository(DataSource datasource) => _ratingProvider(datasource);
}
