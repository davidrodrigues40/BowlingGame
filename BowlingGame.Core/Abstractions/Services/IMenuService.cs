using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Enums;

namespace BowlingGame.Core.Abstractions.Services;

public interface IMenuService
{
    IEnumerable<IMenuItem> GetMenuItems(DataSource dataSource);
}
