using MatchBoardService.Api.Models.Entities;

namespace MatchBoardService.Api.Events;

public class MatchEventStore
{
    public event Func<TeamMatch, ValueTask>? OnMatchCreated;

    public async ValueTask<TeamMatch> CreateTeamMatchCreatedEventAsync(TeamMatch teamMatch)
    {
        // raise, invoke, create event - event ni chaqirish
        if (OnMatchCreated != null)
            await OnMatchCreated(teamMatch);

        return teamMatch;
    }
}