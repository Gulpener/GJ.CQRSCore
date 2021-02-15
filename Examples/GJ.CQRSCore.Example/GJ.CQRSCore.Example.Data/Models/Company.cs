using System;
using System.Collections.Generic;

namespace GJ.CQRSCore.Example.Data.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CEO { get; set; }

        public IList<Guid> OfficeIds { get; set; }
        
    }
}
