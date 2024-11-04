using System.ComponentModel.DataAnnotations;

namespace ECommerceMicroservice.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}

public class CreateProductDto
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
}

public class UpdateProductDto
{
    [Required(ErrorMessage = "Product ID is required.")]
    public int Id { get; set; }

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
}