using BowlingGame.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGame.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MenusController : ControllerBase
{
    private readonly IMenuService _service;

    public MenusController(IMenuService service) => _service = service;

    [HttpGet]
    public IActionResult Get() => Ok(_service.GetMenuItems());
}
