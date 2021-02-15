using System;

namespace GJ.CQRSCore.Example.Models
{
    public class CompanyCeoModel
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CEO { get; set; }
    }
}
