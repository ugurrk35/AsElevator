using AsElevator.Entity.Dto;
using AsElevator.Entity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, GetListCategory>().ReverseMap();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<ProductAttribute, CreateProductAttributeDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Product, UpdateProductCategoryDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>()
               .ForMember(dest => dest.ProductAttributes, opt =>
                   opt.MapFrom(src => src.ProductAttributes.Select(x => new CreateProductAttributeDto
                   {
                       Text = x.Text,
                       Title = x.Title
                   }
                       )))
               .ForMember(dest => dest.Categories, opt =>
               opt.MapFrom(src => src.ProductWithCategories.Select(x => new CreateProductCategoryDto { CategoryID = x.CategoryID, ProductID = x.ProductID })))
               .ReverseMap();

            CreateMap<Product, GetProductForListDto>()
              .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.ProductName))
              .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title))
              .ForMember(x => x.Categories, opt => opt.MapFrom(src => src.ProductWithCategories.Select(x => x.Category.Name)));


            CreateMap<Product, GetProductWithAttributeDto>()
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.ProductName))
              .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title))
              .ForMember(x => x.Attributes, opt => opt.MapFrom(src => src.ProductAttributes));

            CreateMap<ProductAttribute, ProductAttributeDto>();

            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetListProducts>().ReverseMap();
        }
    }
}
