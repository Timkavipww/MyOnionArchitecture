
namespace Domain.Models.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Barcode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Rate {  get; set; }
}
