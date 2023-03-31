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

        public async Task<ProductDto> getSingleProduct(int Id)
        {
            Product product = await _productRepository.FindByKey(Id).ConfigureAwait(false);

            return EntityToClass.productTransform(product);

        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _productRepository.FindAll().ConfigureAwait(false);

            List<ProductDto> allProducts = new();

            foreach(var product in products)
            {
                allProducts.Add(EntityToClass.productTransform(product));
            }

            return allProducts;

        }

        public async Task<Product> createProduct(CreateProductDto productToCreate)
        {
            Product product = await _productRepository.Create(ClassToEntity.CreateProduct(productToCreate)).ConfigureAwait(false);

            return product;

        }

        public async Task<Product> updateProduct(UpdateProductDto productToUpdate)
        {
            Product updateProduct = ClassToEntity.UpdateProduct(productToUpdate);
            Product productCheck = await _productRepository.FindByKey(updateProduct.Id).ConfigureAwait(false);

            if(productCheck == null)
            {
                return null;
            }

            Product product = await _productRepository.Update(updateProduct, updateProduct.Id).ConfigureAwait(false);

            return product;

        }
    }
}

