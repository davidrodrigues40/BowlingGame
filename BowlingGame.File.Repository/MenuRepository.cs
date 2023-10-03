using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Repositories;
using BowlingGame.Dto.Models;

namespace BowlingGame.Files.Repository;
public class MenuRepository : BaseListFileRepository<MenuItem>, IMenuRepository
{
    private readonly string _fileName = "menu.json";

    public IEnumerable<IMenuItem> GetMenuItems() => Get(_fileName);
}
