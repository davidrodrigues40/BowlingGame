using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Repository.Factories;

namespace BowlingGame.Services;

public class MenuService : IMenuService
{
    private readonly MenuRepository _provider;

    public MenuService(MenuRepository provider) => _provider = provider;

    public IEnumerable<IMenuItem> GetMenuItems(DataSource dataSource) => _provider(dataSource).GetMenuItems();
}
