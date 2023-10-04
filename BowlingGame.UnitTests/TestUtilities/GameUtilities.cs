using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Dto.Models;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.TestUtilities;
[ExcludeFromCodeCoverage]
internal static class GameUtilities
{
    public static IGame GeneratePerfectGame()
    {
        IBowler bowler = GenerateBowler("Chuck", 10, 10, 10);
        var game = new Game() { Bowlers = new List<IBowler> { bowler } };

        return game;
    }

    public static IGame GenerateNoMarkGame()
    {
        IBowler bowler = GenerateBowler("Fred", 8, 1, null);
        var game = new Game { Bowlers = new List<IBowler> { bowler } };

        return game;
    }

    public static IGame GenerateAllSpareGame()
    {
        IBowler bowler = GenerateBowler("John", 9, 1, 9);
        Game game = new() { Bowlers = new List<IBowler> { bowler } };

        return game;
    }

    public static IGame GenerateSpareStrikeGame()
    {
        IBowler bowler = GenerateSpareStrikeBowler();
        Game game = new() { Bowlers = new List<IBowler> { bowler } };

        return game;
    }

    public static IBowler GenerateBowler(string name, int firstBall, int secondBall, int? thirdBall)
    {
        List<IFrame> frames = new()
        {
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, firstBall }, {2, secondBall } } },
        };

        if (thirdBall != null)
            frames[^1].Roles.Add(3, (int)thirdBall);

        return new Bowler() { Name = name, Frames = frames.ToDictionary(x => frames.IndexOf(x) + 1, x => x) };
    }

    public static IBowler GenerateSpareStrikeBowler()
    {
        List<IFrame> frames = new()
        {
            new Frame() { Roles = new Dictionary<int, int> { { 1, 9 }, {2, 1 } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, 10 } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, 9 }, {2, 1 } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, 10 } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, 9 }, {2, 1 } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, 10 } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, 9 }, {2, 1 } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, 10 } }},
            new Frame() { Roles = new Dictionary<int, int> { { 1, 9 }, {2, 1 } } },
            new Frame() { Roles = new Dictionary<int, int> { { 1, 10 }, { 2, 9 }, {3, 10 } } }
        };

        return new Bowler() { Name = "Consistant", Frames = frames.ToDictionary(x => frames.IndexOf(x) + 1, x => x) };
    }
}
