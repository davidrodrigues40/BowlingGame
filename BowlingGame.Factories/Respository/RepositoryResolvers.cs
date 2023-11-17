using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Enums;

namespace BowlingGame.Factories.Respository;

public delegate IMenuRepository MenuRepository(DataSource key);
public delegate IRatingRepository RatingRepository(DataSource key);