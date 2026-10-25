namespace AutoDetailingStudio.Services.Data.Service.Request;

public class ServiceCreateDto
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int DurationMinutes { get; set; }

    public string? ImageUrl { get; set; }
}