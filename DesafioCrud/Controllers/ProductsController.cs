using DesafioCrud.Models;
using DesafioCrud.Repository;
using DesafioCrud.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DesafioCrud.Controllers
{
    public class ProductsController : ApiController
    {
        readonly IProductsRepository productsRepository;
        public ProductsController()
        {
            productsRepository = new ProductsRepository();

        }


        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
            try
            {
                List<Product> response = productsRepository.GetProducts();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [HttpGet]
        public HttpResponseMessage GetProductById(int id)
        {
            try
            {
                Product response = productsRepository.GetProductById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = productsRepository.AddProduct(product);
                    Product response = productsRepository.GetProductById(id);

                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = productsRepository.UpdateProduct(product);
                    Product response = productsRepository.GetProductById(id);

                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteProduct(int id)
        {
            try
            {
                productsRepository.DeleteProduct(id);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}