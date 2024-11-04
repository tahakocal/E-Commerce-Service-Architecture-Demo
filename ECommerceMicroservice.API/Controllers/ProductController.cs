using ECommerceMicroservice.Application.DTOs;
using ECommerceMicroservice.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMicroservice.API.Controllers;

/// <summary>
///     Controller for managing products in the e-commerce microservice.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductController" /> class.
    /// </summary>
    /// <param name="productService">The product service used for product operations.</param>
    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    /// <summary>
    ///     Retrieves all products.
    /// </summary>
    /// <returns>A list of products.</returns>
    [HttpGet("List", Name = "GetAllProducts")]
    public ActionResult<IEnumerable<ProductDto>> ListAllProducts()
    {
        var products = _productService.GetAllProducts();
        return Ok(products); // Return the list of products
    }

    /// <summary>
    ///     Retrieves a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product to retrieve.</param>
    /// <returns>The product with the specified identifier.</returns>
    [HttpGet("GetById/{id}", Name = "GetProductById")]
    public ActionResult<ProductDto> GetProductById(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null) return NotFound(); // Return 404 if the product is not found
        return Ok(product); // Return the product
    }

    /// <summary>
    ///     Creates a new product.
    /// </summary>
    /// <param name="productDto">The product DTO to create.</param>
    /// <returns>An <see cref="IActionResult" /> representing the result of the operation.</returns>
    [HttpPost("Create", Name = "CreateProduct")]
    public IActionResult CreateProduct([FromBody] CreateProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState); // Return validation errors
        
        // check if the category exists
        var cetegory =_categoryService.GetCategoryById(productDto.CategoryId);
        if (cetegory == null) return StatusCode(StatusCodes.Status404NotFound, "Category not found."); // Return 404 if the category does not exist

        var createdProduct = _productService.AddProduct(productDto); // Use the DTO

        if (createdProduct == null) //if category is not created
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating product.");
        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id },
            createdProduct); // Return 201 Created
    }

    /// <summary>
    ///     Updates an existing product.
    /// </summary>
    /// <param name="id">The identifier of the product to update.</param>
    /// <param name="productDto">The updated product information.</param>
    /// <returns>An <see cref="IActionResult" /> representing the result of the operation.</returns>
    [HttpPut("Update/{id}", Name = "UpdateProduct")]
    public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState); // Return validation errors
        
        // check if the category exists
        var cetegory =_categoryService.GetCategoryById(productDto.CategoryId);
        if (cetegory == null) return StatusCode(StatusCodes.Status404NotFound, "Category not found."); // Return 404 if the category does not exist

        // check if the product ID in the path matches the product ID in the body
        if (id != productDto.Id) return BadRequest(); // Return 400 Bad Request if IDs do not match

        var updatedProduct = _productService.UpdateProduct(productDto);
        if (updatedProduct == null) return NotFound(); // Return 404 if the product to update does not exist

        return NoContent(); // Return 204 No Content on success
    }

    /// <summary>
    ///     Deletes a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product to delete.</param>
    /// <returns>An <see cref="IActionResult" /> representing the result of the operation.</returns>
    [HttpDelete("Delete/{id}", Name = "DeleteProduct")]
    public IActionResult DeleteProduct(int id)
    {
        var deleted = _productService.DeleteProduct(id);
        if (!deleted) return NotFound(); // Return 404 if the product to delete does not exist

        return NoContent(); // Return 204 No Content after successful deletion
    }
}