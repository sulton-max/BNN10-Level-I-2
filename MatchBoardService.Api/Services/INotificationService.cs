namespace MatchBoardService.Api.Services;

public interface INotificationService
{
    ValueTask SendAsync(Guid userId, string content);
}