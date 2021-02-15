using System;

namespace GJ.CQRSCore.Example.Data.Models
{
    public class Office
    {
        public Guid Id { get; set; }
        public string BuildingName { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
    }
}
