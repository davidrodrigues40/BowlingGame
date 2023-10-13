using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;

namespace BowlingGame.Services;

public class MenuService : IMenuService
{
    private readonly IRepositoryFactory _factory;

    public MenuService(IRepositoryFactory factory) => _factory = factory;

    public IEnumerable<IMenuItem> GetMenuItems(DataSource dataSource) => _factory.CreateMenuRepository(dataSource)!.GetMenuItems();
}
