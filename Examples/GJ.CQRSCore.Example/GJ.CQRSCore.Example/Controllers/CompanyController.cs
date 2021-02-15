using GJ.CQRSCore.Example.Models;
using GJ.CQRSCore.Example.Models.Commands;
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
        private readonly ICommandHandler<AddCompanyWithOfficeCommand> _addCompanyWithOfficeCommandHandler;
        public CompanyController(
            IQueryHandler<GetCompanyWithCeoListQuery, IList<CompanyCeoModel>> getCompanyWithCeoListQueryHandler,
            ICommandHandler<AddCompanyWithOfficeCommand> addCompanyWithOfficeCommandHandler)
        {
            _getCompanyWithCeoListQueryHandler = getCompanyWithCeoListQueryHandler;
            _addCompanyWithOfficeCommandHandler = addCompanyWithOfficeCommandHandler;
        }

        [HttpGet("GetCompanyWithCeoListQuery")]
        public IEnumerable<CompanyCeoModel> Get()
        {
            return _getCompanyWithCeoListQueryHandler.Execute(new GetCompanyWithCeoListQuery());
        }

        [HttpPost("AddCompanyWithOfficeCommand")]
        public IActionResult AddCompanyWithOfficeCommand([FromBody] AddCompanyWithOfficeCommand command)
        {
            if (command == null) throw new ArgumentNullException();

            _addCompanyWithOfficeCommandHandler.Execute(command);

            return Ok();
        }
    }
}
