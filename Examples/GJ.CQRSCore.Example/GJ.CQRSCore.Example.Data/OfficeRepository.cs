using GJ.CQRSCore.Example.Data.Interfaces;
using GJ.CQRSCore.Example.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GJ.CQRSCore.Example.Data
{
    public class OfficeRepository : IOfficeRepository
    {
        public static IList<Office> _offices = new List<Office>();

        public void Add(Office office)
        {
            if (office.Id == null || office.Id == Guid.Empty) throw new ArgumentNullException();
            if (_offices.Any(x => x.Id == office.Id)) throw new ArgumentException("Id already exists");

            _offices.Add(office);
        }

        public Office Get(Guid id)
        {
            if (id == null || id == Guid.Empty) throw new ArgumentNullException();

            return _offices.FirstOrDefault(x => x.Id == id);
        }

        public IList<Office> GetAll()
        {
            return _offices;
        }

        public void Remove(Guid id)
        {
            if (id == null || id == Guid.Empty) throw new ArgumentNullException();

            _offices.Remove(Get(id));
        }

        public void Replace(Office office)
        {
            if (office.Id == null || office.Id == Guid.Empty) throw new ArgumentNullException();
            Remove(office.Id);
            Add(office);
        }
    }
}
