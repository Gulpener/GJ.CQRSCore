using GJ.CQRSCore.Example.Data.Models;
using System;
using System.Collections.Generic;

namespace GJ.CQRSCore.Example.Data.Interfaces
{
    public interface IOfficeRepository
    {
        Office Get(Guid id);
        IList<Office> GetAll();

        void Add(Office company);
        void Remove(Guid id);

        void Replace(Office office);
    }
}
