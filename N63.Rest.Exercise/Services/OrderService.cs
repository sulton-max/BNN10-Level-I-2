using N63.Rest.Exercise.Models;

namespace N63.Rest.Exercise.Services;

public class OrderService
{
    public ValueTask<Order> CreateOrderAsync(Order order) => new(order);
}