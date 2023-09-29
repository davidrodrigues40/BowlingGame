using BowlingGame.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGame.Bff.Controllers;
[Route("api/ratings")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingsController(IRatingService ratingService) => _ratingService = ratingService;

    [HttpGet]
    public IActionResult GetRatings() => Ok(_ratingService.GetRatings());
}
