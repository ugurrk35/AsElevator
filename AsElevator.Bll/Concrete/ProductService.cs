using AsElevator.Bll.Abstract;
using AsElevator.Dal.Abstract;
using AsElevator.Entity.Dto;
using AsElevator.Entity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Bll.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Product> AddProductAndCategory(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            if (product.ProductAttributes.Count() < 2)
            {
                throw new ValidationException("There should be at least 2 attribute.");
            }        
            if (productDto.Categories == null || productDto.Categories.Length == 0)
            {
                throw new ValidationException("You must enter at least one category.");
            }
            await _productRepository.AddProduct(product);

            foreach (var category in productDto.Categories)
            {
                await _productRepository.AddProductCategory(product.Id, category);
            }
            return product;
        }

        public async Task<GetProductForListDto> GetProductAndCategory(int id)
        {
            return _mapper.Map<GetProductForListDto>(await _productRepository.GetProductWithCategory(id));
        }

        public async Task<GetProductWithAttributeDto> GetProductWithAttributeDto(int id)
        {

            return _mapper.Map<GetProductWithAttributeDto>(await _productRepository.GetProduct(id));
        }
    }
}
