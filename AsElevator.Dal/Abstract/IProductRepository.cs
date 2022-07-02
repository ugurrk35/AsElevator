using AsElevator.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Dal.Abstract
{
    public interface IProductRepository
    {
        Task AddProduct<T>(T entity) where T : class;

        //Task<List<Product>> GetProducts(ProductParams questionParams);
        Task<Product> GetProduct(int id);
        Task<Product> GetProductWithCategory(int id);
        Task AddProductCategory(int id, int cat);
        Task<Product> UpdateProduct(Product item, int id);
        Task<bool> SaveAll();
        Task UpdateProduct(int id, Product ownerEntity);
        Task<List<Product>> GetAll();
    }
}
