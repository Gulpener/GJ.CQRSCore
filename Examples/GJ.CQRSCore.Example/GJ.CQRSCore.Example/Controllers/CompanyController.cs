using GJ.CQRSCore.Example.Models;
using GJ.CQRSCore.Example.Models.Queries;
using GJ.CQRSCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GJ.CQRSCore.Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IQueryHandler<GetCompanyWithCeoListQuery, IList<CompanyCeoModel>> _getCompanyWithCeoListQueryHandler;
        public CompanyController(IQueryHandler<GetCompanyWithCeoListQuery, IList<CompanyCeoModel>> getCompanyWithCeoListQueryHandler)
        {
            _getCompanyWithCeoListQueryHandler = getCompanyWithCeoListQueryHandler;
        }

        [HttpGet("GetCompanyWithCeoListQuery")]
        public IEnumerable<CompanyCeoModel> Get()
        {
            return _getCompanyWithCeoListQueryHandler.Execute(new GetCompanyWithCeoListQuery());
        }
    }
}
