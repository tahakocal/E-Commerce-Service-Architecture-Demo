using ECommerceMicroservice.Application.DTOs;

namespace ECommerceMicroservice.Application.Services;

public interface IProductService
{
    /// <summary>
    ///     Retrieves all products.
    /// </summary>
    /// <returns>An enumerable collection of product DTOs.</returns>
    IEnumerable<ProductDto> GetAllProducts();

    /// <summary>
    ///     Retrieves a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product.</param>
    /// <returns>The product DTO with the specified identifier, or null if not found.</returns>
    ProductDto? GetProductById(int id);

    /// <summary>
    ///     Adds a new product.
    /// </summary>
    /// <param name="productDto">The product DTO to add.</param>
    /// <returns>The added product DTO.</returns>
    ProductDto AddProduct(CreateProductDto productDto);

    /// <summary>
    ///     Updates an existing product.
    /// </summary>
    /// <param name="productDto">The product DTO with updated information.</param>
    /// <returns>The updated product DTO, or null if not found.</returns>
    ProductDto? UpdateProduct(UpdateProductDto productDto);

    /// <summary>
    ///     Deletes a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product to delete.</param>
    /// <returns>True if the product was deleted; otherwise, false.</returns>
    bool DeleteProduct(int id);
}