using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Enums;

namespace BowlingGame.Core.Abstractions.Services;
public interface IRepositoryFactory
{
    IMenuRepository? CreateMenuRepository(DataSource datasource);
    IRatingRepository? CreateRatingRepository(DataSource datasource);
}
