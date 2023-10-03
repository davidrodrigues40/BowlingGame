using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Repository.Factories;
using BowlingGame.Services;
using System.Diagnostics.CodeAnalysis;

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
         .AddScoped<IBowlService, BowlService>()
         .AddScoped<IPlayerService, PlayerService>()
         .AddScoped<IScoreCalculator, ScoreCalculator>()
         .AddScoped<IMenuService, MenuService>()
         .AddScoped<IRatingService, RatingService>();

        // resolvers
        _ = services
            .AddTransient<MenuRepositoryProvider>(provider => key =>
            {
                return key switch
                {
                    DataSource.InMemory => provider.GetService<Code.Repository.MenuRepository>()!,
                    DataSource.File => provider.GetService<Files.Repository.MenuRepository>()!,
                    _ => throw new KeyNotFoundException(key.ToString()),
                };
            })
            .AddTransient<RatingRepositoryProvider>(provider => key =>
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
