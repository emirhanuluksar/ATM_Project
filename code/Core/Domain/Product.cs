namespace Domain;

public class Product : IEntity {
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductImageUrl { get; set; } = string.Empty;
    public decimal ProductPrice { get; set; }
    public DateTime ProductCreationTime { get; set; }
}
