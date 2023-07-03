namespace Domain;

public class Testimonial : Document {
    public string TestimonialName { get; set; } = string.Empty;
    public string TestimonialView { get; set; } = string.Empty;
    public DateTime TestimonialViewDate { get; set; }
}
