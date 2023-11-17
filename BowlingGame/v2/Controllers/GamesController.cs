using BowlingGame.Core.Abstractions.Models.v2;
using BowlingGame.Core.Abstractions.Services.v2;
using BowlingGame.Core.Models.v2;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGame.Api.v2.Controllers;
[Route("api/games")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly IGameServiceV2 _service;

    public GamesController(IGameServiceV2 service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult StartGame(List<Bowler> bowlers)
    {
        IGame game = _service.NewGame(bowlers);
        return Ok(game);
    }

    [HttpGet]
    [Route("roll")]
    public IActionResult RollBall(int pins, int bowlerRating)
    {
        var remaining = _service.RollBall(pins, bowlerRating);

        return Ok(remaining);
    }
}
