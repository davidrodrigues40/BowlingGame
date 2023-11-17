using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Abstractions.Services.v2;
using BowlingGame.Core.Enums;
using BowlingGame.Factories;
using BowlingGame.Factories.Respository;
using BowlingGame.Services;
using System.Diagnostics.CodeAnalysis;
using v2Services = BowlingGame.Services.v2;

namespace BowlingGame.Api.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // factories
        _ = services.AddScoped<IRepositoryFactory, RepositoryFactory>();

        // services
        _ = services.AddScoped<IRatingService, RatingService>()
         .AddScoped<IGameService, GameService>()
         .AddScoped<IGameServiceV2, v2Services.GameService>()
         .AddScoped<IBowlService, BowlService>()
         .AddScoped<IPlayerService, PlayerService>()
         .AddScoped<IScoreCalculator, ScoreCalculator>()
         .AddScoped<IMenuService, MenuService>()
         .AddScoped<IRatingService, RatingService>()
         .AddScoped<IScorecardGenerator, v2Services.ScorecardGenerator>();

        // resolvers
        _ = services
            .AddTransient<MenuRepository>(provider => key =>
            {
                return key switch
                {
                    DataSource.InMemory => provider.GetService<Code.Repository.MenuRepository>()!,
                    DataSource.File => provider.GetService<Files.Repository.MenuRepository>()!,
                    _ => throw new KeyNotFoundException(key.ToString()),
                };
            })
            .AddTransient<RatingRepository>(provider => key =>
            {
                return key switch
                {
                    DataSource.InMemory => provider.GetService<Code.Repository.RatingRepository>()!,
                    DataSource.File => provider.GetService<Files.Repository.RatingRepository>()!,
                    _ => throw new KeyNotFoundException(key.ToString()),
                };
            });

        // repositories
        _ = services.AddScoped<Files.Repository.MenuRepository>()
            .AddScoped<Code.Repository.MenuRepository>()
            .AddScoped<Files.Repository.RatingRepository>()
            .AddScoped<Code.Repository.RatingRepository>();

        return services;
    }
}
