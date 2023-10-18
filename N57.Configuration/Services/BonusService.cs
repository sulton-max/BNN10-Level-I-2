using N57.Configuration.Models;

namespace N57.Configuration.Services;

public class BonusService
{
    private readonly List<Bonus> _bonus = new();

    public ValueTask AddBonus(int userId, int amount)
    {
        var foundBonus = _bonus.FirstOrDefault(b => b.UserId == userId);

        if (foundBonus is null)
            _bonus.Add(new Bonus(){UserId = userId, BonusAmount = amount});
        else
            foundBonus.BonusAmount += amount;

        return ValueTask.CompletedTask;
    }
}