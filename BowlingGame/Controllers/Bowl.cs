using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
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
		public IActionResult BowlGame()
		{
			IGame game = _gameService.NewGame();

			return Ok(_gameService.PlayGame(game));
		}
	}
}