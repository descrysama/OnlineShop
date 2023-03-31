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
    public async Task<IActionResult> Create(CreateProductDto newProduct)
    {
        Product createdProduct = await _productService.createProduct(newProduct).ConfigureAwait(false);

        if (createdProduct != null)
        {
            return Ok(EntityToClass.productTransform(createdProduct));
        }
        else
        {
            return BadRequest("Produit non crée, Veuillez verifier vos entrées.");
        }
    }

    [Authorize]
    [HttpPatch()]
    public async Task<IActionResult> Update(UpdateProductDto newProduct)
    {
        Product createdProduct = await _productService.updateProduct(newProduct).ConfigureAwait(false);

        if (createdProduct != null)
        {
            return Ok(EntityToClass.productTransform(createdProduct));
        }
        else
        {
            return BadRequest("Produit non modifié, le produit n'existe pas ou l'Id est mauvais.");
        }
    }

}

