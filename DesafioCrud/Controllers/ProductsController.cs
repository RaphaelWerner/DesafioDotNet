using DesafioCrud.Models;
using DesafioCrud.Repository;
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
        readonly ProductsRepository productsRepository;
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
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
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
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                int id = productsRepository.AddProduct(product);
                Product response = productsRepository.GetProductById(id);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        public HttpResponseMessage UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                int id = productsRepository.UpdateProduct(product);
                Product response = productsRepository.GetProductById(id);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteProduct(int id)
        {
            try
            {
                productsRepository.DeleteProduct(id);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


    }
}