using Microsoft.AspNetCore.Mvc;
using Api.OnlineShop.Services;
using Api.OnlineShop.Dtos;
using Api.OnlineShop.Dtos.Mapper;
using Api.OnlineShop.Datas.Entities.Entities;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Api.OnlineShop.Utilities;

namespace Api.OnlineShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [Authorize]
    [HttpPost("create")]
    public async Task<ProductDto> Create(CreateProductDto newProduct)
    {
        Product product = ClassToEntity.CreateProduct(newProduct);
        Product createdProduct = await _productService.createProduct(newProduct).ConfigureAwait(false);

        if (createdProduct != null)
        {
            return EntityToClass.productTransform(createdProduct);
        }
        else
        {
            return null;
        }
    }

}

