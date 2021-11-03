using AmarDaktar.Repositories.Abastractions.IUnitWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AmarDaktarApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        public AppController(IUnitOfWork iUnitOfWork)
        {

        }
    }
}
