using MatchBoardService.Api.Events;
using MatchBoardService.Api.Models.Entities;

namespace MatchBoardService.Api.Services;

public class PromotionService
{
    private readonly MatchEventStore _matchEventStore;
    private readonly IEnumerable<INotificationService> _notificationServices;
    private readonly UserService _userService;

    public PromotionService(MatchEventStore matchEventStore, IEnumerable<INotificationService> notificationServices, UserService userService)
    {
        _matchEventStore = matchEventStore;
        _notificationServices = notificationServices;
        _userService = userService;

        _matchEventStore.OnMatchCreated += HandleTeamMatchCreatedEventAsync;
    }

    private async ValueTask HandleTeamMatchCreatedEventAsync(TeamMatch teamMatch)
    {
        var usersQuery = _userService.Users.Where(user => user.LikedTeams.Any(teamId => teamId == teamMatch.TeamA || teamId == teamMatch.TeamB));
        var users = usersQuery.ToList();

        var notifyUsersTask = users.Select(user =>
            Task.WhenAll(_notificationServices
                .Select(notificationService => notificationService
                    .SendAsync(user.Id, $"Match between {teamMatch.TeamA} and {teamMatch.TeamB} will start at {teamMatch.MatchTime}.").AsTask())));

        await Task.WhenAll(notifyUsersTask);
    }
}