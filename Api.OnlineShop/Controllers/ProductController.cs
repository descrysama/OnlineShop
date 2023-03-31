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

    [HttpGet()]
    public async Task<IActionResult> getAll()
    {
        List<ProductDto> product = await _productService.GetAll().ConfigureAwait(false);

        if (product != null)
        {
            return Ok(product);
        }
        else
        {
            return BadRequest("Produit non crée, Veuillez verifier vos entrées.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle([FromRoute] int id)
    {
        try
        {
            ProductDto product = await _productService.getSingleProduct(id).ConfigureAwait(false);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest("Produit non crée, Veuillez verifier vos entrées.");
            }

        } catch(Exception error)
        {
            return BadRequest("Id non valide, seulement les entiers sont autorisés.");
        }
    }

    [Authorize]
    [HttpPost()]
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

