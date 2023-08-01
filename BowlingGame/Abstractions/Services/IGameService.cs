using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services;

public interface IGameService
{
	IGame NewGame();
	IGame PlayGame(IGame game);
}