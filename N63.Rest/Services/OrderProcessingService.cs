using System.ComponentModel.DataAnnotations;
using N63.Rest.Models;

namespace N63.Rest.Services;

public class OrderProcessingService
{
    private readonly OrderService _orderService;
    private readonly EmailSenderService _emailSenderService;

    public OrderProcessingService(OrderService orderService, EmailSenderService emailSenderService)
    {
        _orderService = orderService;
        _emailSenderService = emailSenderService;
    }

    public async ValueTask<Order> CreateOrderAsync(IList<Guid> productsId, Guid customerId)
    {
        ValidateAndThrowExceptionOnCreateOrder(productsId);

        var order = new Order
        {
            ProductsId = productsId,
            CustomerId = customerId
        };

        var createdOrder = await _orderService.CreateOrderAsync(order);
        var sendEmailResult = await _emailSenderService.SendAsync(
            "john.doe@gmail.com",
            "Your order has been placed",
            $"Order {order.Id} has been placed");

        if (!sendEmailResult)
            throw new InvalidOperationException("Email was not sent");

        return createdOrder;
    }

    private void ValidateAndThrowExceptionOnCreateOrder(IEnumerable<Guid> productsId)
    {
        var invalidProductsId = productsId.Where(productId => productId == Guid.Empty).ToList();
        if (!invalidProductsId.Any()) return;

        var exception = new ArgumentException($"Invalid product Id values - {string.Join(',', invalidProductsId)}", nameof(productsId));
        throw new ValidationException("Products have invalid values, contact support", exception);
    }
}