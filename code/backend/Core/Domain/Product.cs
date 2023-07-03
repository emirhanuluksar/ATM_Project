namespace Domain;

public class Product : Document {
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
}
