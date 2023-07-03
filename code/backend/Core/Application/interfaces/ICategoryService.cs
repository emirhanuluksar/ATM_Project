using System;
using Domain;

namespace Application.interfaces;

public interface ICategoryService {
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category updateCategory);
    Task<Category> DeleteCategoryAsync(int categoryId);
    Category? GetCategoryById(int categoryId);
    List<Category> GetCategories();
    int GetCategoriesCount();
}
