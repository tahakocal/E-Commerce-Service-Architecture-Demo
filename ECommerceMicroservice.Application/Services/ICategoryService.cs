using ECommerceMicroservice.Application.DTOs;

namespace ECommerceMicroservice.Application.Services;

public interface ICategoryService
{
    /// <summary>
    ///     Retrieves all categories.
    /// </summary>
    /// <returns>An enumerable collection of categories.</returns>
    IEnumerable<CategoryDto> GetAllCategories();

    /// <summary>
    ///     Retrieves a category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category.</param>
    /// <returns>The category with the specified identifier, or null if not found.</returns>
    CategoryDto? GetCategoryById(int id);

    /// <summary>
    ///     Adds a new category.
    /// </summary>
    /// <param name="categoryDto">The category to add.</param>
    /// <returns>The added category DTO.</returns>
    CategoryDto AddCategories(CreateCategoryDto categoryDto);

    /// <summary>
    ///     Updates an existing category.
    /// </summary>
    /// <param name="categoryDto">The category with updated information.</param>
    /// <returns>The updated category DTO, or null if not found.</returns>
    CategoryDto? UpdateCategory(UpdateCategoryDto categoryDto);

    /// <summary>
    ///     Deletes a category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category to delete.</param>
    /// <returns>True if the category was deleted; otherwise, false.</returns>
    bool DeleteCategory(int id);
}