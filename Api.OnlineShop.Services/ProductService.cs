using System;
using Api.OnlineShop.Datas.Repository.Contract;
using Api.OnlineShop.Datas.Entities.Entities;
using Api.OnlineShop.Dtos;
using Api.OnlineShop.Dtos.Mapper;
using Api.OnlineShop.Datas.Repository;

namespace Api.OnlineShop.Services
{
	public class ProductService
	{

		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

        public async Task<Product> createProduct(CreateProductDto productToCreate)
        {
            Product product = await _productRepository.Create(ClassToEntity.CreateProduct(productToCreate)).ConfigureAwait(false);

            return product;

        }

        public async Task<Product> updateProduct(UpdateProductDto productToUpdate)
        {
            Product product = await _productRepository.Update(ClassToEntity.UpdateProduct(productToUpdate)).ConfigureAwait(false);

            return product;

        }
    }
}

