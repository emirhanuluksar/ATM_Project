using Domain;

namespace Application.interfaces;

public interface IProductService {
    Task<Product> AddProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product updateProduct);
    Task<Product> DeleteProductAsync(int productId);
    Product? GetProductById(int productId);
    List<Product> GetProducts();
    int GetProductsCount();
}
