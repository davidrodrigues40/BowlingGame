using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Models;

namespace BowlingGame.Code.Repository;
public class MenuRepository : IMenuRepository
{
    private readonly string[] _items = { "Books", "Facts", "Bowling" };
    public IEnumerable<IMenuItem> GetMenuItems()
    {
        Array.Sort(_items);
        foreach (string item in _items)
        {
            yield return new MenuItem { Value = item, Route = item.ToLower() };
        }
    }
}
