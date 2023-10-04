using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Enums;

namespace BowlingGame.Repository.Factories;

public delegate IMenuRepository MenuRepositoryProvider(DataSource key);
public delegate IRatingRepository RatingRepositoryProvider(DataSource key);