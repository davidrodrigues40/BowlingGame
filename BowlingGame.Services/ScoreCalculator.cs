using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Dto.Models;

namespace BowlingGame.Services;

public class ScoreCalculator : IScoreCalculator
{

    public void CalculateScore(IGame game)
    {
        foreach (IBowler bowler in game.Bowlers)
        {
            CalculateBowlerScore(bowler);
        }

        game.Winner = CalculateWinner(game.Bowlers);
    }

    public Dictionary<int, IFrame> ClearScoreSheet()
    {
        var frames = new Dictionary<int, IFrame>();

        for (int x = 1; x <= 10; x++)
            frames.Add(x, new Frame());

        return frames;
    }

    private static IScoreCard CalculateWinner(IEnumerable<IBowler> bowlers)
    {
        ScoreCard winner = new() { Name = bowlers.First().Name, Score = bowlers.First().Score };

        foreach (IBowler bowler in bowlers)
        {
            if (bowler.Score == winner.Score && bowler.Name != winner.Name)
                winner.Name += $" and {bowler.Name}";
            else
            if (bowler.Score > winner.Score)
                winner = winner with { Name = bowler.Name, Score = bowler.Score };
        }

        return winner;
    }

    private static void CalculateBowlerScore(IBowler bowler)
    {
        bowler.Score = 0;
        try
        {
            for (int x = 1; x <= 10; x++)
            {
                IFrame frame = bowler.Frames[x];
                IFrame nextFrame;

                switch (x)
                {
                    case 10:
                        ProcessTenthFrame(frame);
                        break;
                    case 9:
                        nextFrame = bowler.Frames[x + 1];
                        ProcessNinthFrame(frame, nextFrame);
                        break;
                    default:
                        {
                            nextFrame = bowler.Frames[x + 1];
                            IFrame nextNextFrame = bowler.Frames[x + 2];
                            ProcessFrame(frame, nextFrame, nextNextFrame);
                            break;
                        }
                }

                bowler.Score += frame.Score;
            }
        }
        catch (Exception)
        {
            //TODO: Log exception
            throw;
        }
    }

    private static void ProcessFrame(IFrame frame, IFrame nextFrame, IFrame nextNextFrame)
    {
        if (frame.Roles[1] == 10) // strike
            ProcessStrike(frame, nextFrame, nextNextFrame);
        else if (frame.Roles[1] + frame.Roles[2] == 10) // spare
            ProcessSpare(frame, nextFrame);
        else // open frame
            ProcessOpenFrame(frame);
    }

    private static void ProcessStrike(IFrame frame, IFrame nextFrame, IFrame nextNextFrame)
    {
        frame.Score = 10;

        if (nextFrame.Roles[1] == 10)
            frame.Score += 10 + nextNextFrame.Roles[1];
        else
            frame.Score = 10 + nextFrame.Roles[1] + nextFrame.Roles[2];
    }

    private static void ProcessSpare(IFrame frame, IFrame nextFrame) => frame.Score = 10 + nextFrame.Roles[1];

    private static void ProcessOpenFrame(IFrame frame) => frame.Score = frame.Roles[1] + frame.Roles[2];

    private static void ProcessNinthFrame(IFrame frame, IFrame nextFrame)
    {
        if (frame.Roles[1] == 10)
            frame.Score = 10 + nextFrame.Roles[1] + nextFrame.Roles[2];
        else if (frame.Roles[1] + frame.Roles[2] == 10)
            frame.Score = 10 + nextFrame.Roles[1];
        else
            ProcessOpenFrame(frame);
    }

    private static void ProcessTenthFrame(IFrame frame)
    {
        if (frame.Roles[1] == 10)
            frame.Score = 10 + frame.Roles[2] + frame.Roles[3];
        else if (frame.Roles[1] + frame.Roles[2] == 10)
            frame.Score = 10 + frame.Roles[3];
        else
            ProcessOpenFrame(frame);
    }
}