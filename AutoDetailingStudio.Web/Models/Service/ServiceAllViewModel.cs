namespace AutoDetailingStudio.Web.Models.Service;
public class ServiceAllViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    
}