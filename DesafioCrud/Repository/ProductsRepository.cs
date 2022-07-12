using DesafioCrud.Models;
using DesafioCrud.Repository.DbConnection;
using DesafioCrud.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DesafioCrud.Repository
{
    public class ProductsRepository : DbConnection.DbConnection, IProductsRepository
    {
        
        public List<Product> GetProducts()
        {
            try
            {
                OpenConnection();

                command = new SqlCommand("GetProducts", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.ExecuteNonQuery();

                var productsList = new List<Product>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product();
                        product.Id = (int)reader["id"];
                        product.Name = (string)reader["name"];
                        product.Price = (Decimal)reader["price"];
                        product.Brand = (string)reader["brand"];
                        productsList.Add(product);
                    }
                }

                return productsList;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Retornar Produtos: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                OpenConnection();

                command = new SqlCommand("GetProductById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

                var product = new Product();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product.Id = (int)reader["id"];
                    product.Name = (string)reader["name"];
                    product.Price = (Decimal)reader["price"];
                    product.Brand = (string)reader["brand"];
                    product.CreatedAt = (DateTime)reader["createdAt"];
                    product.UpdateAt = (DateTime)reader["updateAt"];
                }

                return product;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Retornar o Produto: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int AddProduct(Product product)
        {
            try
            {
                OpenConnection();

                command = new SqlCommand("AddProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@brand", product.Brand);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);
                command.Parameters.AddWithValue("@updateAt", DateTime.Now);

                var id = Convert.ToInt32(command.ExecuteScalar());

                return id;
     
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Adicionar Novo Produto: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int UpdateProduct(Product product)
        {
            try
            {
                OpenConnection();

                if (GetProductById(product.Id).Id == 0)
                    throw new Exception("Produto Não Existe");

                command = new SqlCommand("UpdateProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", product.Id);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@brand", product.Brand);
                command.Parameters.AddWithValue("@updateAt", DateTime.Now);

                command.ExecuteScalar();

                return product.Id;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Editar Produto: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int DeleteProduct(int id)
        {
            try
            {
                OpenConnection();

                command = new SqlCommand("DeleteProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                var produtoExcluido = command.ExecuteNonQuery() > 0;

                if(!produtoExcluido)
                    throw new Exception("Nenhum produto Excluido");

                return id;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Excluir Produto: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}