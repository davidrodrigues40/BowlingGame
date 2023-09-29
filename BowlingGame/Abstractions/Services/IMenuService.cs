using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services;

public interface IMenuService
{
    IEnumerable<IMenuItem> GetMenuItems();
}
