namespace WebApplication1.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public int? CompanyId { get; set; }
    public Company? Companies { get; set; }
}