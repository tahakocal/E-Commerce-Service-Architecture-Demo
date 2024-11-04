using ECommerceMicroservice.Application.DTOs;
using ECommerceMicroservice.Domain.Entities;
using ECommerceMicroservice.Infrastructure.Repositories;

namespace ECommerceMicroservice.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly CategoryRepository _repository;

    public CategoryService(CategoryRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    ///     Retrieves all categories.
    /// </summary>
    /// <returns>An enumerable collection of categories.</returns>
    public IEnumerable<CategoryDto> GetAllCategories()
    {
        var categories = _repository.GetAllCategories();
        return categories.Select(categories => new CategoryDto
        {
            Id = categories.Id, // assuming Id is a property in Category
            Name = categories.Name
        });
    }

    /// <summary>
    ///     Retrieves a category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category.</param>
    /// <returns>The category with the specified identifier, or null if not found.</returns>
    public CategoryDto? GetCategoryById(int id)
    {
        var category = _repository.GetCategoryById(id);
        if (category == null) return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    /// <summary>
    ///     Adds a new category.
    /// </summary>
    /// <param name="category">The category to add.</param>
    public CategoryDto AddCategories(CreateCategoryDto categoryDto)
    {
        var category = new Category
        {
            Name = categoryDto.Name
        };

        _repository.AddCategory(category);
        return new CategoryDto
        {
            Id = category.Id, // Assuming the Id is generated on save
            Name = category.Name
        };
    }

    /// <summary>
    ///     Updates an existing category.
    /// </summary>
    /// <param name="categoryDto">The category with updated information.</param>
    public CategoryDto? UpdateCategory(UpdateCategoryDto categoryDto)
    {
        var category = _repository.GetCategoryById(categoryDto.Id);
        if (category == null) return null;

        category.Name = categoryDto.Name;

        _repository.UpdateCategory(category);

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }


    /// <summary>
    ///     Deletes a category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category to delete.</param>
    public bool DeleteCategory(int id)
    {
        return _repository.DeleteCategory(id);
    }
}