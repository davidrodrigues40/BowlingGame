using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Repository.Factories;

namespace BowlingGame.Services;

public class MenuService : IMenuService
{
    private readonly MenuRepositoryProvider _provider;

    public MenuService(MenuRepositoryProvider provider) => _provider = provider;

    public IEnumerable<IMenuItem> GetMenuItems(DataSource dataSource) => _provider(dataSource).GetMenuItems();
}
