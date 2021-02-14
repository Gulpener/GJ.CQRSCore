using GJ.CQRSCore.Example.Data.Interfaces;
using GJ.CQRSCore.Example.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GJ.CQRSCore.Example.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        public static IList<Company> _companies = new List<Company>();

        public void Add(Company company)
        {
            if (company.Id == null || company.Id == Guid.Empty) throw new ArgumentNullException();
            if (_companies.Any(x => x.Id == company.Id)) throw new ArgumentException("Id already exists");

            _companies.Add(company);
        }

        public Company Get(Guid id)
        {
            if (id == null || id == Guid.Empty) throw new ArgumentNullException();

            return _companies.FirstOrDefault(x => x.Id == id);
        }

        public IList<Company> GetAll()
        {
            return _companies;
        }

        public void Remove(Guid id)
        {
            if (id == null || id == Guid.Empty) throw new ArgumentNullException();

            _companies.Remove(Get(id));
        }

        public void Replace(Company company)
        {
            if (company.Id == null || company.Id == Guid.Empty) throw new ArgumentNullException();
            Remove(company.Id);
            Add(company);
        }
    }
}
