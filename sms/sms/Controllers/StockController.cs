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

    public class StockController : AppController
    {
        private IStockService _service;
        
        private readonly IWebHostEnvironment _hostEnvironment;
        public StockController(IStockService iService, IUnitOfWork iUnitOfWork, IWebHostEnvironment hostEnvironment) : base(iUnitOfWork)
        {
            _service = iService;
           
            this._hostEnvironment = hostEnvironment;

        }
       
        [HttpGet("Get")]
        public ICollection<Stock> GetStock()
        {
             var data = _service.GetAll();
            
            return data;
        }

        [HttpGet("GetChartData")]
        public IEnumerable<dynamic> GetChartData()
        {
            var data = _service.GetChartData();

            return data;
        }


        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StockController>
        [HttpPost("Create")]
        public async Task<ActionResult<Stock>> Post(Stock stockModel)
        {
            bool isSubmitterd;
            var stock = _service.GetAll().ToList().FirstOrDefault(p => p.ProductId == stockModel.ProductId && p.UpazilaId==stockModel.UpazilaId);
            if (stock is null)
            {
                isSubmitterd = _service.Add(stockModel);
            }
            else
            {
                stock.Quantity += stockModel.Quantity;
                isSubmitterd= _service.Update(stock);
            }
            
            
            
            if (isSubmitterd)
                return stockModel;
            return Ok("Not Saved");
        }


        // PUT api/<StockController>/5
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Stock stock)
        {
            try
            {
                var result = await _service.UpdateAsync(stock);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       

    }


}
