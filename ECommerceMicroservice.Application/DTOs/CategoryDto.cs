using System.ComponentModel.DataAnnotations;

namespace ECommerceMicroservice.Application.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ProductDto> Products { get; set; } = new();
}

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Category name is required.")]
    [StringLength(100, ErrorMessage = "Category name cannot be longer than 100 characters.")]
    public string Name { get; set; }
}

public class UpdateCategoryDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Category name is required.")]
    [StringLength(100, ErrorMessage = "Category name cannot be longer than 100 characters.")]
    public string Name { get; set; }
}