using Application.interfaces;
using Application.Utilities.Exceptions;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.services;

public class ProductService : IProductService {
    private readonly IProductDal _productDal;
    private readonly ILogger<ProductService> _logger;
    public ProductService(IProductDal repository, ILogger<ProductService> logger) {
        _productDal = repository;
        _logger = logger;
    }
    public async Task<Product> AddProductAsync(Product product) {
        _logger.LogDebug("ProductService.AddProductAsync() method is started.");
        var result = GetIfProductExists(product);
        if (!result) {
            throw new ProductAlreadyExistsException("This product already exists");
        }
        await _productDal.AddAsync(product);
        return product;
    }

    public async Task<Product> DeleteProductAsync(int productId) {
        _logger.LogDebug("ProductService.DeleteProductAsync() method is started.");
        var result = GetProductById(productId);
        if (result is null) {
            throw new ProductNotFoundException("Product not found");
        }
        await _productDal.DeleteAsync(result);
        return result;
    }

    public Product? GetProductById(int productId) {
        _logger.LogDebug("ProductService.GetProductById() method is started.");
        return _productDal.FindById(productId);
    }

    public List<Product> GetProducts() {
        _logger.LogDebug("ProductService.Getproducts() method is started.");
        return _productDal.GetList().ToList();
    }

    public int GetProductsCount() {
        _logger.LogDebug("ProductService.GetProductsCount() method is started.");
        return _productDal.GetList().Count;
    }

    public async Task<Product> UpdateProductAsync(Product updateProduct) {
        _logger.LogDebug("ProductService.UpdateProductAsync() method is started.");
        await _productDal.UpdateAsync(updateProduct);
        return updateProduct;
    }

    private bool GetIfProductExists(Product product) {
        var result = _productDal.Get(x => x.Id == product.Id || x.ProductName == product.ProductName);
        return result is null;
    }
}
