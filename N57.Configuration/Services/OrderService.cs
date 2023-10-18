using Microsoft.Extensions.Options;
using N57.Configuration.Models;
using N57.Configuration.Models.Settings;

namespace N57.Configuration.Services;

public class OrderService
{
    private readonly BonusService _bonusService;
    private readonly OrderSettings _orderSettings;
    private readonly List<Order> _orders = new();

    public OrderService(BonusService bonusService, OrderSettings orderSettings)
    {
        _bonusService = bonusService;
        _orderSettings = orderSettings;
    }

    public ValueTask AddOrder(Order order)
    {
        while (true)
        {
            _orderSettings.Value
        }

        _orders.Add(order);

        if (order.OrderAmount > 100)
            _bonusService.AddBonus(order.UserId, CalculateBonus(order.OrderAmount));

        return ValueTask.CompletedTask;
    }

    public int CalculateBonus(int orderAmount)
    {
        return orderAmount * _orderSettings.BonusPercentage / 100;
    }
}