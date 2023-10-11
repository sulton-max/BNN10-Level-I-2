using MatchBoardService.Api.Models.Entities;
using MatchBoardService.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchBoardService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamMatchesController : ControllerBase
{
    private readonly MatchService _matchService;

    public TeamMatchesController(MatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateMatch([FromBody] TeamMatch match)
    {
        var createdMatch = await _matchService.CreateAsync(match);
        return Ok(createdMatch);
    }
}