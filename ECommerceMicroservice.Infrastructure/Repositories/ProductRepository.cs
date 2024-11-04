using ECommerceMicroservice.Domain.Entities;
using ECommerceMicroservice.Infrastructure.Data;

namespace ECommerceMicroservice.Infrastructure.Repositories;

public class ProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Retrieves all products.
    /// </summary>
    /// <returns>A list of products.</returns>
    public List<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    /// <summary>
    ///     Retrieves a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product.</param>
    /// <returns>The product with the specified identifier, or null if not found.</returns>
    public Product? GetProductById(int id)
    {
        return _context.Products.Find(id); // Use Find for a primary key lookup.
    }

    /// <summary>
    ///     Adds a new product to the database.
    /// </summary>
    /// <param name="product">The product to add.</param>
    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    /// <summary>
    ///     Updates an existing product in the database.
    /// </summary>
    /// <param name="product">The product with updated information.</param>
    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges(); // Save changes to the database.
    }

    /// <summary>
    ///     Deletes a product by its identifier from the database.
    /// </summary>
    /// <param name="id">The identifier of the product to delete.</param>
    public bool DeleteProduct(int id)
    {
        var product = _context.Products.Find(id); // Find the product to delete
        if (product != null)
        {
            _context.Products.Remove(product); // Remove the product from the context
            _context.SaveChanges(); // Save changes to the database
            return true;
        }

        return false;
    }
}