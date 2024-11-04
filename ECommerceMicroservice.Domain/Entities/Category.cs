using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerceMicroservice.Domain.Entities;

public class Category : IEntity
{
    [Required(ErrorMessage = "Category name is required.")]
    [StringLength(100, ErrorMessage = "Category name cannot be longer than 100 characters.")]
    public string Name { get; set; }
    [JsonIgnore]
    public List<Product>? Products { get; set; }
}