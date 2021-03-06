using AmarDaktar.Repositories.Abastractions.IUnitWork;
using AmarDaktarApp.Controllers;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.BLL.Contracts.IEntityService;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet("SearchByDistrictId/{id}")]
        public ICollection<Stock> SearchByDistrictId(long id)
        {
            var data = _service.GetAll().Where(stock=>stock.Upazila.DistrictId == id).ToList();
            return data;
        }
        [HttpGet("SearchByDivisonId/{id}")]
        public ICollection<Stock> SearchByDivisonId(long id)
        {
            var data = _service.GetAll().Where(stock => stock.Upazila.District.DivisonId == id).ToList();
            return data;
        }
        [HttpGet("SearchByUpazilaId/{id}")]
        public ICollection<Stock> SearchByUpazilaId(long id)
        {
            var data = _service.GetAll().Where(stock => stock.UpazilaId == id).ToList();
            return data;
        }

        [HttpGet("GetChartData")]
        public IEnumerable<dynamic> GetChartData()
        {
            var data = _service.GetChartData();

            return data;
        }


       

        
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
            {
                GetChartData();
                return stockModel;
            }
               
            return Ok("Not Saved");
        }


        
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

       
        
        [HttpGet("getReport")]
        public FileContentResult GetReport()
        {

            var dt = _service.GetReportData();
            string mimeType = "";
            int extension = 1;
            var path = Path.Combine(_hostEnvironment.ContentRootPath, "reports", "rpStock.rdlc");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "RDLC report (Set as parameter)");
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("dsStock", dt);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        [Route("GetByUpazilaID/{id}")]
        public ICollection<Stock> GetByUpazilaID(long id)
        {
            var data = _service.GetDataByUpazilaId(id);


            return data.ToList();
        }

    }


}
