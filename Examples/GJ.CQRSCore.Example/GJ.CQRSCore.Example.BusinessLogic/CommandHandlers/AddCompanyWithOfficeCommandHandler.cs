using GJ.CQRSCore.Example.Data.Interfaces;
using GJ.CQRSCore.Example.Data.Models;
using GJ.CQRSCore.Example.Models.Commands;
using System;
using System.Collections.Generic;

namespace GJ.CQRSCore.Example.BusinessLogic.CommandHandlers
{
    public class AddCompanyWithOfficeCommandHandler : CommandHandlerBase<AddCompanyWithOfficeCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IOfficeRepository _officeRepository;

        public AddCompanyWithOfficeCommandHandler(ICompanyRepository companyRepository, IOfficeRepository officeRepository)
        {
            _companyRepository = companyRepository;
            _officeRepository = officeRepository;
        }

        public override void Handle(AddCompanyWithOfficeCommand command)
        {
            var office = new Office() {
                Id = Guid.NewGuid(),
                BuildingName = command.BuildingName,
                Street = command.Street,
                HouseNumber = command.HouseNumber,
                City = command.City
            };
            var company = new Company() {
                Id = Guid.NewGuid(),
                Name = command.CompanyName,
                CEO = command.CEO,
            };
            company.OfficeIds = new List<Guid>();
            company.OfficeIds.Add(office.Id);

            _companyRepository.Add(company);
            _officeRepository.Add(office);
        }
    }
}
