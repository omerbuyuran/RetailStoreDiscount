﻿using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Responses;

namespace RetailStoreDiscounts.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<ProductResponse> AddProduct(Product product)
        {
            try
            {
                await productRepository.AddProductAsync(product);
                await unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse(ex.Message);
            }
        }

        public async Task<ProductResponse> GetProductByIdAsync(int productId)
        {
            try
            {
                Product product = await productRepository.GetProductByIdAsync(productId);
                if (product==null)
                {
                    return new ProductResponse("Ürün bulunamadı");
                }
                else
                {
                    return new ProductResponse(product);
                }
            }
            catch (Exception ex)
            {
                return new ProductResponse(ex.Message);
            }
        }

        public async Task<ProductListResponse> ListAsync()
        {
            try
            {
                IEnumerable<Product> products = await productRepository.ListAsync();
                return new ProductListResponse(products);
            }
            catch (Exception ex)
            {
                return new ProductListResponse(ex.Message);
            }
        }

        public async Task<ProductResponse> RemoveProduct(int productId)
        {
            try
            {
                Product product = await productRepository.GetProductByIdAsync(productId);
                if (product==null)
                {
                    return new ProductResponse("Ürün bulunamadı");
                }
                else
                {
                    await productRepository.RemoveProductAsync(productId);
                    await unitOfWork.CompleteAsync();
                    return new ProductResponse(product);
                }
            }
            catch (Exception ex)
            {

                return new ProductResponse(ex.Message);
            }
        }

        public async Task<ProductResponse> UpdateProduct(Product product, int productId)
        {
            try
            {
                var firstProduct = await productRepository.GetProductByIdAsync(productId);
                if (firstProduct==null)
                {
                    return new ProductResponse("Ürün bulunamadı");
                }
                else
                {
                    firstProduct.Name= product.Name;
                    firstProduct.Price= product.Price;
                    firstProduct.Category= product.Category;
                    productRepository.UpdateProduct(firstProduct);
                    await unitOfWork.CompleteAsync();

                    return new ProductResponse(firstProduct);
                }
            }
            catch (Exception ex)
            {
                return new ProductResponse(ex.Message);
            }
        }
    }
}
