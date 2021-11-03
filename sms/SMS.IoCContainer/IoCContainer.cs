using AmarDaktar.Repositories.Abastractions.IUnitWork;
using AmarDaktar.Repositories.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using SMS.BLL.Contracts.IEntityService;
using SMS.BLL.EntityService;
using SMS.BLLEntityService;
using SMS.DataBaseContext;
using SMS.Repositories.Abastractions.IEntity;
using SMS.Repositories.EntityRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.IoCContainer
{
    public static class IoCContainer
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IProductService,ProductService>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IDistrictService,DistrictService>();
            services.AddTransient<IDistrictRepository,DistrictRepository>();
            services.AddTransient<IDivisonService, DivisonService>();
            services.AddTransient<IDivisonRepository, DivisonRepository>();
            services.AddTransient<IUpazilaService, UpazilaService>();
            services.AddTransient<IUpazilaRepository, UpazilaRepository>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IStockRepository, StockRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<SMSDbContext>();
            
        }
    }
}
