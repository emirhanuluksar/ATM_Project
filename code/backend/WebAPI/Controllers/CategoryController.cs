using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UluarSite.Common.Web;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ApiController {
    private readonly ICategoryService _categoryService;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService) {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpGet("getallcategories")]
    public List<Category> GetAllCategories() {
        return _categoryService.GetCategories();
    }

    [HttpGet("GetCategoryById/{id:int}")]
    public Category GetCategoryById(int id) {
        return _categoryService.GetCategoryById(id) ?? new();
    }

    [HttpPost("AddCategory")]
    public async Task<CreatedAtActionResult> AddCategoryAsync(Category category) {
        var result = await _categoryService.AddCategoryAsync(category);
        return CreatedAtGetCategoryById(result);
    }

    private CreatedAtActionResult CreatedAtGetCategoryById(Category category) {
        return CreatedAtAction(actionName: nameof(GetCategoryById), routeValues: new { id = category.Id }, value: category);

    }
}

