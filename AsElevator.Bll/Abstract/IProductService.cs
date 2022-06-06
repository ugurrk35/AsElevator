using AsElevator.Entity.Dto;
using AsElevator.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Bll.Abstract
{
    public interface IProductService
    {
        Task<Product> AddProductAndCategory(CreateProductDto product);
        Task<GetProductForListDto> GetProductAndCategory(int id);
        Task<GetProductWithAttributeDto> GetProductWithAttributeDto(int id);
    }
}
