using BowlingGame.Abstractions.Models;
using BowlingGame.Core.Enums;

namespace BowlingGame.Abstractions.Services;

public interface IMenuService
{
    IEnumerable<IMenuItem> GetMenuItems(DataSource dataSource);
}
