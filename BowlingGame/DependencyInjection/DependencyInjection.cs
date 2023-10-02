using BowlingGame.Abstractions.Services;
using BowlingGame.Services;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.Api.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddScoped<IRatingService, RatingService>()
        .AddSingleton<IGameService, GameService>()
        .AddSingleton<IBowlService, BowlService>()
        .AddSingleton<IPlayerService, PlayerService>()
        .AddSingleton<IScoreCalculator, ScoreCalculator>()
        .AddSingleton<IMenuService, MenuService>()
        .AddSingleton<IRatingService, RatingService>();
}
