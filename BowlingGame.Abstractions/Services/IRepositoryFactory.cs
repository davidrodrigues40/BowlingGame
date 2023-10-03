using BowlingGame.Abstractions.Repositories;
using BowlingGame.Core.Enums;

namespace BowlingGame.Abstractions.Services;
public interface IRepositoryFactory
{
    IMenuRepository? CreateMenuRepository(DataSource datasource);
    IRatingRepository? CreateRatingRepository(DataSource datasource);
}
