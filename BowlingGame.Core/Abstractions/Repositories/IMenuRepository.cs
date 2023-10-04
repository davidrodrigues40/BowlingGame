using BowlingGame.Core.Abstractions.Models;

namespace BowlingGame.Core.Abstractions.Repositories;
public interface IMenuRepository
{
    IEnumerable<IMenuItem> GetMenuItems();
}
