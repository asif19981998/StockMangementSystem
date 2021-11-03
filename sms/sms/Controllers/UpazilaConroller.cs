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

    public class UpazilaController : AppController
    {
        private IUpazilaService _service;
        
        private readonly IWebHostEnvironment _hostEnvironment;
        public UpazilaController(IUpazilaService iService, IUnitOfWork iUnitOfWork, IWebHostEnvironment hostEnvironment) : base(iUnitOfWork)
        {
            _service = iService;
           
           

        }
      
        [HttpGet]
        public ICollection<Upazila> GetDistrict()
        {
            var data = _service.GetAll();


            return data;
        }

        [HttpGet]
        [Route("GetByDistrictID/{id}")]
        public ICollection<Upazila> GetDistrictByDivisonId(int id)
        {
            var data = _service.GetUpazilasByDivisonId(id);


            return data.ToList();
        }











    }


}
