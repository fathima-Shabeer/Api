namespace PracticeApi.Models;

// A simple model. Each property becomes a field in the JSON.
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
