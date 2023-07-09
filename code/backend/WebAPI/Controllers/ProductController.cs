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
public class ProductController : ApiController {
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IProductService productService) {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet("GetAllProducts")]
    public List<Product> GetAllProducts() {
        return _productService.GetProducts();
    }

    [HttpGet("GetProductById/{id:int}")]
    public Product GetProductById(int id) {
        return _productService.GetProductById(id) ?? new();
    }

    [HttpPost("AddProduct")]
    public async Task<CreatedAtActionResult> AddProductAsync(Product product) {
        var result = await _productService.AddProductAsync(product);
        return CreatedAtGetProductById(result);
    }

    private CreatedAtActionResult CreatedAtGetProductById(Product product) {
        return CreatedAtAction(actionName: nameof(GetProductById), routeValues: new { id = product.Id }, value: product);
    }
}

