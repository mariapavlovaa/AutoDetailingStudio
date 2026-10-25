namespace AutoDetailingStudio.Web.Models.Service;

public class ServiceDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public int DurationMinutes { get; set; }
}