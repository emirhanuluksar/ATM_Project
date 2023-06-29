namespace Domain;

public class Post : IEntity {
    public int PostId { get; set; }
    public string PostTitle { get; set; } = string.Empty;
    public string PostDescription { get; set; } = string.Empty;
    public string ProductImageUrl { get; set; } = string.Empty;
    public DateTime ProductCreationTime { get; set; }
}
