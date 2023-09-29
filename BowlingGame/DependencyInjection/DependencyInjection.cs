using BowlingGame.Abstractions.Services;
using BowlingGame.Services;

namespace BowlingGame.Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddScoped<IRatingService, RatingService>()
        .AddSingleton<IGameService, GameService>()
        .AddSingleton<IBowlService, BowlService>()
        .AddSingleton<IRatedGameService, RatedGameService>()
        .AddSingleton<IScoreCalculator, ScoreCalculator>()
        .AddSingleton<IMenuService, MenuService>()
        .AddSingleton<IRatingService, RatingService>();
}
