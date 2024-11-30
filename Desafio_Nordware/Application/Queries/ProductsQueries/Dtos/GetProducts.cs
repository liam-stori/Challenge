namespace App.Application.Queries.ProductsQueries.Dtos;

public class GetProducts
{
    public long Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public int Quantity { get; set; } = default!;
    public string NameStatus { get; set; } = default!;
}
