namespace Domain;

public class Testimonial : IEntity {
    public int TestimonialId { get; set; }
    public string TestimonialName { get; set; } = string.Empty;
    public string TestimonialView { get; set; } = string.Empty;
    public DateTime TestimonialViewDate { get; set; }
}
