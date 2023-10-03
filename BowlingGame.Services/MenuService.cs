using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Repositories;
using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;

namespace BowlingGame.Services;

public class MenuService : IMenuService
{
    private readonly IRepositoryFactory _factory;

    public MenuService(IRepositoryFactory factory) => _factory = factory;

    public IEnumerable<IMenuItem> GetMenuItems()
    {
        IMenuRepository? repository = _factory.CreateMenuRepository(DataSource.InMemory);

        return repository is null ? throw new InvalidOperationException("Repository is null") : repository.GetMenuItems();
    }

    public IEnumerable<IMenuItem> GetMenuItems(DataSource dataSource)
    {
        IMenuRepository? repository = _factory.CreateMenuRepository(dataSource);

        return repository is null ? throw new InvalidOperationException("Repository is null") : repository.GetMenuItems();
    }
}
