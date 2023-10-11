using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGame.Api.Controllers;
/// <summary>
/// This controller is used to get the ratings.
/// It uses a factory architecture to get the ratings from the correct repository.
/// </summary>
[Route("api/ratings")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingsController(IRatingService ratingService) => _ratingService = ratingService;

    [HttpGet]
    public IActionResult GetRatings(DataSource dataSource) => Ok(_ratingService.GetRatings(dataSource));
}
