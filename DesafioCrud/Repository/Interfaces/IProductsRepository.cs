using DesafioCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCrud.Repository.Interfaces
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        int DeleteProduct(int id);

    }
}
