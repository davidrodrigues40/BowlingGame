using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Dto.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGame.Api.Controllers;

[Route("api/")]
[ApiController]
public class BowlController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IPlayerService _playerService;

    public BowlController(IGameService gameService, IPlayerService playerService)
    {
        _gameService = gameService;
        _playerService = playerService;
    }

    [HttpPost]
    [Route("game")]
    [ProducesResponseType(typeof(Game), 200)]
    public IActionResult Bowl(List<Player>? players)
    {
        if (players == null || players.Count == 0)
            return BadRequest("No players provided");

        var bowlers = _playerService.GenerateBowlers(players).ToList();

        var game = (Game)_gameService.NewGame(bowlers);
        game = (Game)_gameService.PlayGame(game);

        return Ok(game);
    }
}