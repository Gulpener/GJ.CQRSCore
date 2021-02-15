using System;
using System.Collections.Generic;
using GJ.CQRSCore.Example.Data.Models;

namespace GJ.CQRSCore.Example.Data.Interfaces
{
    public interface ICompanyRepository
    {
        Company Get(Guid id);
        IList<Company> GetAll();

        void Add(Company company);
        void Remove(Guid id);

        void Replace(Company company);
    }
}
