using ECommerceMicroservice.Application.DTOs;
using ECommerceMicroservice.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMicroservice.API.Controllers;

/// <summary>
///     Controller for managing categories in the e-commerce microservice.
/// </summary>
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryController" /> class.
    /// </summary>
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    ///     Retrieves all categories.
    /// </summary>
    /// <returns>A list of categories.</returns>
    [HttpGet("List", Name = "ListAllCategories")]
    public ActionResult<IEnumerable<CategoryDto>> ListAllCategories()
    {
        return Ok(_categoryService.GetAllCategories());
    }

    /// <summary>
    ///     Retrieves a category by id.
    /// </summary>
    /// <param name="id">The identifier of the category to retrieve.</param>
    /// <returns>An <see cref="ActionResult{Category}" /> representing the requested category.</returns>
    [HttpGet("GetById/{id}", Name = "GetCategoryById")]
    public ActionResult<CategoryDto> GetCategoryById(int id)
    {
        var category = _categoryService.GetCategoryById(id);
        if (category == null) return NotFound(); // Return 404 if the category is not found
        return Ok(category);
    }

    /// <summary>
    ///     Creates a new category.
    /// </summary>
    /// <param name="categoryDto">The categoryDTO to create.</param>
    /// <returns>An <see cref="IActionResult" /> representing the result of the operation.</returns>
    [HttpPost("Create", Name = "CreateCategory")]
    public IActionResult CreateCategory(CreateCategoryDto categoryDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState); // Return validation errors

        var createdCategory = _categoryService.AddCategories(categoryDto);

        if (createdCategory == null) //if category is not created
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating category.");
        return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, categoryDto);
    }

    /// <summary>
    ///     Updates an existing category.
    /// </summary>
    /// <param name="categoryDto">The category with updated information.</param>
    /// <param name="id">The identifier of the category to update.</param>
    /// <returns>An <see cref="IActionResult" /> representing the result of the operation.</returns>
    [HttpPut("Update/{id}", Name = "UpdateCategory")]
    public IActionResult UpdateCategory(int id, UpdateCategoryDto categoryDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState); // Return validation errors

        if (id != categoryDto.Id) return BadRequest("Category ID mismatch."); // Return 400 if IDs do not match

        _categoryService.UpdateCategory(categoryDto);
        return Ok(); // Return 200 OK on successful update
    }

    /// <summary>
    ///     Deletes a category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category to delete.</param>
    /// <returns>An <see cref="IActionResult" /> representing the result of the operation.</returns>
    [HttpDelete("Delete/{id}", Name = "DeleteCategory")]
    public IActionResult DeleteCategory(int id)
    {
        _categoryService.DeleteCategory(id);
        return Ok(); // Return 200 OK on successful deletion
    }
}