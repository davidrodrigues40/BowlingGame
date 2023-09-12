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

		[HttpPost]
		[ProducesResponseType(typeof(Game), 200)]
		public IActionResult Bowl(List<Player> players)
		{
			if (players == null || players.Count == 0)
				return BowlGame();

			List<Bowler> bowlers = new ();
			foreach (var player in players)
			{
                // add player to game
				bowlers.Add( new Bowler() {  Name = player.Name });
            }

			IGame game = _gameService.NewGame(bowlers);
			game = _gameService.PlayGame(game);

			return Ok(game);

		}

		private IActionResult BowlGame()
		{
			Bowler bowler1 = new() { Name = "Bowler 1" };

			IGame game = _gameService.NewGame(new List<IBowler> { bowler1 });

			return Ok(_gameService.PlayGame(game));
		}
    }
}