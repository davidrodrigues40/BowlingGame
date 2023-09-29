using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Models;

namespace BowlingGame.Services;

public class MenuService : IMenuService
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
