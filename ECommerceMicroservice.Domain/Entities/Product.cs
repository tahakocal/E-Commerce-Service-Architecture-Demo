using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerceMicroservice.Domain.Entities;

public class Product : IEntity
{
    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100, ErrorMessage = "Product name cannot be longer than 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Stock quantity is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
    public int Stock { get; set; }

    [Required(ErrorMessage = "Category Id is required.")]
    public int CategoryId { get; set; }

    [JsonIgnore] public Category? Category { get; set; }
}