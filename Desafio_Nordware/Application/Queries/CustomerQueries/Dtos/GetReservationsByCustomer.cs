namespace App.Application.Queries.CustomerQueries.Dtos;

public class GetReservationsByCustomer
{
    public string NameProduct { get; set; } = default!;
    public string CategoryProduct { get; set; } = default!;
    public decimal PriceForProduct { get; set; } = default!;
    public decimal TotalPrice { get; set; } = default!;
    public int QuantityReservation { get; set; } = default!;
    public DateTime ReservedAt { get; set; } = default!;
    public string StatusReservation { get; set; } = default!;
}
