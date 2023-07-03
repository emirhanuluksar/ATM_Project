using Application.interfaces;
using Application.Utilities.Exceptions;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.services;

public class CategoryService : ICategoryService {
    private readonly IRepository<Category> _repository;
    private readonly ILogger<CategoryService> _logger;
    public CategoryService(IRepository<Category> repository, ILogger<CategoryService> logger) {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Category> AddCategoryAsync(Category category) {
        _logger.LogDebug("CategoryService.AddCategoryAsync() method is started.");
        var result = GetIfCategoryExists(category);
        if (!result) {
            throw new CategoryAlreadyExistsException("This category already exists");
        }
        await _repository.AddAsync(category);
        return category;
    }

    public async Task<Category> DeleteCategoryAsync(int categoryId) {
        _logger.LogDebug("CategoryService.DeleteCategoryAsync() method is started.");
        var result = GetCategoryById(categoryId);
        if (result is null) {
            throw new CategoryNotFoundException("Category not found");
        }
        await _repository.DeleteAsync(result);
        return result;

    }

    public List<Category> GetCategories() {
        _logger.LogDebug("CategoryService.GetCategories() method is started.");
        return _repository.GetList().ToList();
    }

    public int GetCategoriesCount() {
        _logger.LogDebug("CategoryService.GetCategoriesCount() method is started.");
        return _repository.GetList().Count;
    }

    public Category? GetCategoryById(int categoryId) {
        _logger.LogDebug("CategoryService.GetCategoryById() method is started.");
        return _repository.FindById(categoryId);
    }

    // ? için kontrol yapılacak

    public async Task<Category> UpdateCategoryAsync(Category updateCategory) {
        _logger.LogDebug("CategoryService.UpdateCategoryAsync() method is started.");
        await _repository.UpdateAsync(updateCategory);
        return updateCategory;
    }

    private bool GetIfCategoryExists(Category category) {
        var result = _repository.Get(x => x.Id == category.Id && string.Equals(x.CategoryName, category.CategoryName, StringComparison.OrdinalIgnoreCase));
        return result is null;
    }
}
