namespace Domain;

public class Post : Document {
    public int CategoryId { get; set; }
    public string PostTitle { get; set; } = string.Empty;
    public string PostDescription { get; set; } = string.Empty;
    public DateTime PostCreationTime { get; set; }
}
