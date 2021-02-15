using GJ.CQRSCore.Interfaces;
using System;

namespace GJ.CQRSCore.Example.Models.Commands
{
    public class AddCompanyWithOfficeCommand : ICommand
    {
        public string CompanyName { get; set; }
        public string CEO { get; set; }
        public string BuildingName { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
    }
}
