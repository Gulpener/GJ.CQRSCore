using GJ.CQRSCore.Example.BusinessLogic.CommandHandlers;
using GJ.CQRSCore.Example.BusinessLogic.QueryHandlers;
using GJ.CQRSCore.Example.BusinessLogic.Validator;
using GJ.CQRSCore.Example.Data;
using GJ.CQRSCore.Example.Data.Interfaces;
using GJ.CQRSCore.Example.Data.Models;
using GJ.CQRSCore.Example.Models;
using GJ.CQRSCore.Example.Models.Commands;
using GJ.CQRSCore.Example.Models.Queries;
using GJ.CQRSCore.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GJ.CQRSCore.Example
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IQueryHandler<GetCompanyWithCeoListQuery, IList<CompanyCeoModel>>, GetCompanyWithCeoListQueryHandler>();
            services.AddScoped<ICommandHandler<AddCompanyWithOfficeCommand>, AddCompanyWithOfficeCommandHandler>();
            services.AddScoped<IValidator<AddCompanyWithOfficeCommand>, AddCompanyWithOfficeCommandValidator>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            ICompanyRepository companyRepo, 
            IOfficeRepository officeRepo)
        {
            TestData.GenerateStartupInfo(companyRepo, officeRepo);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
