using System;
using Domain;

namespace Application.interfaces;

public interface ICategoryService {
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category updateCategory);
    Task<Category> DeleteCategoryAsync(int categoryId);
    Category? GetCategoryById(int categoryId);
    IList<Category> GetCategories();
    int GetCategoriesCount();
}
