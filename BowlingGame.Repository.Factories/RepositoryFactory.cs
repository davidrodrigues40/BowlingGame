using BowlingGame.Abstractions.Repositories;
using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;

namespace BowlingGame.Repository.Factories;
public class RepositoryFactory : IRepositoryFactory
{
    private readonly MenuRepositoryResolver _menuProvider;
    private readonly RatingRepositoryResolver _ratingProvider;

    public RepositoryFactory(MenuRepositoryResolver menuProvider, RatingRepositoryResolver ratingProvider)
    {
        _menuProvider = menuProvider;
        _ratingProvider = ratingProvider;
    }

    public IMenuRepository? CreateMenuRepository(DataSource datasource) => _menuProvider(datasource);
    public IRatingRepository? CreateRatingRepository(DataSource datasource) => _ratingProvider(datasource);
}
