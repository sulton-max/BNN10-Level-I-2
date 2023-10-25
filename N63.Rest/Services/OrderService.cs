using N63.Rest.Models;

namespace N63.Rest.Services;

public class OrderService
{
    public ValueTask<Order> CreateOrderAsync(Order order) => new(order);
}