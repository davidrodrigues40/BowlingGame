using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGame.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BowlController : ControllerBase
	{
		private readonly IGameService _gameService;

		public BowlController(IGameService gameService)
		{
			_gameService = gameService;
		}

		[HttpGet]
		public IActionResult BowlGame([FromQuery]string[] players)
		{
			if (players == null || players.Length == 0)
				return BowlGame();

			List<IBowler> bowlers = new ();
			foreach (var player in players)
			{
                // add player to game
				bowlers.Add( new Bowler() { Name = player });
            }

			IGame game = _gameService.NewGame(bowlers);

			return Ok(_gameService.PlayGame(game));

		}

		private IActionResult BowlGame()
		{
			Bowler bowler1 = new() { Name = "Bowler 1" };

			IGame game = _gameService.NewGame(new List<IBowler> { bowler1 });

			return Ok(_gameService.PlayGame(game));
		}
    }
}