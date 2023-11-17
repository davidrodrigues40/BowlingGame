using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGame.Api.Controllers;
/// <summary>
/// This controller is used to get the menu items.
/// It uses a factory architecture to get the menu items from the correct repository.
/// </summary>
[Route("api/menus")]
[ApiController]
public class MenusController : ControllerBase
{
    private readonly IMenuService _service;

    public MenusController(IMenuService service) => _service = service;

    [HttpGet]
    public IActionResult Get(DataSource dataSource) => Ok(_service.GetMenuItems(dataSource));
}
