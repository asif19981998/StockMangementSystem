using AmarDaktar.Repositories.Abastractions.IUnitWork;
using AmarDaktarApp.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.BLL.Contracts.IEntityService;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : AppController
    {
        private IProductService _service;
        
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IProductService iService, IUnitOfWork iUnitOfWork, IWebHostEnvironment hostEnvironment) : base(iUnitOfWork)
        {
            _service = iService;
           
            this._hostEnvironment = hostEnvironment;

        }
        // GET: api/<ProductController>
        //[HttpGet]
        //public ICollection<Product> Get()
        //{
        //    return _service.GetAll();
        //}
        [HttpGet("Get")]
        public ICollection<Product> GetProduct()
        {
            var data = _service.GetAll();
            return data;
        }

      
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost("Create")]
        public async Task<ActionResult<Product>> Post(Product productModel)
        {
          
            bool isSubmitterd = _service.Add(productModel);
            if (isSubmitterd)
                return productModel;
            return Ok("Not Saved");
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Product product)
        {
            try
            {
                var result = await _service.UpdateAsync(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       

    }


}
