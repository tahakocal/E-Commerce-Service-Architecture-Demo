using ECommerceMicroservice.Application.DTOs;
using ECommerceMicroservice.Domain.Entities;
using ECommerceMicroservice.Infrastructure.Repositories;

namespace ECommerceMicroservice.Application.Services;

public class ProductService : IProductService
{
    private readonly ProductRepository _repository;

    public ProductService(ProductRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    ///     Retrieves all products.
    /// </summary>
    /// <returns>An enumerable collection of product DTOs.</returns>
    public IEnumerable<ProductDto> GetAllProducts()
    {
        var products = _repository.GetAllProducts();
        return products.Select(product => new ProductDto
        {
            Id = product.Id, // assuming Id is a property in Product
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId
        });
    }

    /// <summary>
    ///     Retrieves a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product.</param>
    /// <returns>The product DTO with the specified identifier, or null if not found.</returns>
    public ProductDto? GetProductById(int id)
    {
        var product = _repository.GetProductById(id);
        if (product == null) return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId
        };
    }

    /// <summary>
    ///     Adds a new product.
    /// </summary>
    /// <param name="productDto">The product DTO to add.</param>
    /// <returns>The added product DTO.</returns>
    public ProductDto AddProduct(CreateProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Stock = productDto.Stock,
            CategoryId = productDto.CategoryId
        };

        _repository.AddProduct(product);
        return new ProductDto
        {
            Id = product.Id, // Assuming the Id is generated on save
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId
        };
    }

    /// <summary>
    ///     Updates an existing product.
    /// </summary>
    /// <param name="productDto">The product DTO with updated information.</param>
    /// <returns>The updated product DTO, or null if not found.</returns>
    public ProductDto? UpdateProduct(UpdateProductDto productDto)
    {
        var product = _repository.GetProductById(productDto.Id);
        if (product == null) return null;

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.Stock = productDto.Stock;
        product.CategoryId = productDto.CategoryId;

        _repository.UpdateProduct(product);

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId
        };
    }

    /// <summary>
    ///     Deletes a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product to delete.</param>
    /// <returns>True if the product was deleted; otherwise, false.</returns>
    public bool DeleteProduct(int id)
    {
        return _repository.DeleteProduct(id);
    }
}