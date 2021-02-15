using GJ.CQRSCore.Example.Data.Interfaces;
using GJ.CQRSCore.Example.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GJ.CQRSCore.Example.Data
{
    public static class TestData
    {
        public static void GenerateStartupInfo(ICompanyRepository companyRepo, IOfficeRepository officeRepo)
        {

            var company1 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "The Big Great Company",
                CEO = "Peter Johnson",
                OfficeIds = new List<Guid>()
            };

            var office1 = new Office()
            {
                Id = Guid.NewGuid(),
                BuildingName = "Building Numer One",
                Street = "Downstreet",
                HouseNumber = 1,
                City = "Boston",
            };
            
            company1.OfficeIds.Add(office1.Id);
            companyRepo.Add(company1);
            officeRepo.Add(office1);

            var company2 = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "The Small Company",
                CEO = "Jan Janssen",
                OfficeIds = new List<Guid>()
            };

            companyRepo.Add(company2);
        }
    }
}
