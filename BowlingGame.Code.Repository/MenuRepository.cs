using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Models;

namespace BowlingGame.Code.Repository;
public class MenuRepository : IMenuRepository
{
    private readonly string[] _routes = { "books", "facts", "bowling-v1", "bowling-v2" };
    private readonly string[] _items = { "Books", "Facts", "Bowling Version 1", "Bowling Version 2" };
    public IEnumerable<IMenuItem> GetMenuItems()
    {
        foreach (string route in _routes)
        {
            yield return new MenuItem { Value = _items[Array.IndexOf(_routes, route)], Route = route };
        }
    }
}
