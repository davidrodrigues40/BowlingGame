using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Repositories;
public interface IMenuRepository
{
    IEnumerable<IMenuItem> GetMenuItems();
}
