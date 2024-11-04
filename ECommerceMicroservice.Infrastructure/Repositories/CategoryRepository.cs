using ECommerceMicroservice.Domain.Entities;
using ECommerceMicroservice.Infrastructure.Data;

namespace ECommerceMicroservice.Infrastructure.Repositories;

public class CategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Retrieves all categories from the database.
    /// </summary>
    /// <returns>A list of categories.</returns>
    public List<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }

    /// <summary>
    ///     Retrieves a category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category.</param>
    /// <returns>The category with the specified identifier, or null if not found.</returns>
    public Category? GetCategoryById(int id)
    {
        return _context.Categories.Find(id); // Efficient primary key lookup
    }

    /// <summary>
    ///     Adds a new category to the database.
    /// </summary>
    /// <param name="category">The category to add.</param>
    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges(); // Save changes to the database
    }

    /// <summary>
    ///     Updates an existing category in the database.
    /// </summary>
    /// <param name="category">The category with updated information.</param>
    public void UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges(); // Save changes to the database
    }

    /// <summary>
    ///     Deletes a category by its identifier from the database.
    /// </summary>
    /// <param name="id">The identifier of the category to delete.</param>
    public bool DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id); // Find the category to delete
        if (category != null)
        {
            _context.Categories.Remove(category); // Remove the category from the context
            _context.SaveChanges(); // Save changes to the database
            return true;
        }

        return false;
    }
}