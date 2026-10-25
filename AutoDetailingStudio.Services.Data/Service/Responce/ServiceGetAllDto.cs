namespace AutoDetailingStudio.Services.Data.Service.Responce;

public class ServiceGetAllDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }
}