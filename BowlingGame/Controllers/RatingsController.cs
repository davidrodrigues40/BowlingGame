using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BowlingGame.Api.Controllers;
[Route("api/ratings")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingsController(IRatingService ratingService) => _ratingService = ratingService;

    [HttpGet]
    public IActionResult GetRatings(DataSource dataSource) => Ok(_ratingService.GetRatings(dataSource));
}
