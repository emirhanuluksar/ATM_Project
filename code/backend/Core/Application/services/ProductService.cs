using Application.interfaces;
using Application.Utilities.Exceptions;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.services;

public class ProductService : IProductService {
    private readonly IRepository<Product> _repository;
    private readonly ILogger<ProductService> _logger;
    public ProductService(IRepository<Product> repository, ILogger<ProductService> logger) {
        _repository = repository;
        _logger = logger;
    }
    public async Task<Product> AddProductAsync(Product product) {
        _logger.LogDebug("ProductService.AddProductAsync() method is started.");
        var result = GetIfProductExists(product);
        if (!result) {
            throw new ProductAlreadyExistsException("This product already exists");
        }
        await _repository.AddAsync(product);
        return product;
    }

    public async Task<Product> DeleteProductAsync(int productId) {
        _logger.LogDebug("ProductService.DeleteProductAsync() method is started.");
        var result = GetProductById(productId);
        if (result is null) {
            throw new ProductNotFoundException("Product not found");
        }
        await _repository.DeleteAsync(result);
        return result;
    }

    public Product? GetProductById(int productId) {
        _logger.LogDebug("ProductService.GetProductById() method is started.");
        return _repository.FindById(productId);
    }

    public List<Product> GetProducts() {
        _logger.LogDebug("ProductService.Getproducts() method is started.");
        return _repository.GetList().ToList();
    }

    public int GetProductsCount() {
        _logger.LogDebug("ProductService.GetProductsCount() method is started.");
        return _repository.GetList().Count;
    }

    public async Task<Product> UpdateProductAsync(Product updateProduct) {
        _logger.LogDebug("ProductService.UpdateProductAsync() method is started.");
        await _repository.UpdateAsync(updateProduct);
        return updateProduct;
    }

    private bool GetIfProductExists(Product product) {
        var result = _repository.Get(x => x.Id == product.Id && string.Equals(x.ProductName, product.ProductName, StringComparison.OrdinalIgnoreCase));
        return result is null;
    }
}
