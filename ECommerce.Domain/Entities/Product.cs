namespace ECommerce.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public bool IsValid()
    {
        return Price > 0;
    }
}