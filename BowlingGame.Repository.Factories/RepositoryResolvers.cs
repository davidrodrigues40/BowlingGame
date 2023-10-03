using BowlingGame.Abstractions.Repositories;
using BowlingGame.Core.Enums;

namespace BowlingGame.Repository.Factories;

public delegate IMenuRepository MenuRepositoryResolver(DataSource key);
public delegate IRatingRepository RatingRepositoryResolver(DataSource key);