namespace N63.Rest.Models;

public class Order
{
    public IEnumerable<Guid> ProductsId { get; set; } = default!;

    public Guid CustomerId { get; set; }

    public Guid Id { get; set; }
}