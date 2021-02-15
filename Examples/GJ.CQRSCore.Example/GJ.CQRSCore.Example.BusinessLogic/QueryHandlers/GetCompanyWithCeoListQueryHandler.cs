using GJ.CQRSCore.Example.Data.Interfaces;
using GJ.CQRSCore.Example.Models;
using GJ.CQRSCore.Example.Models.Queries;
using System.Collections.Generic;
using System.Linq;

namespace GJ.CQRSCore.Example.BusinessLogic.QueryHandlers
{
    public class GetCompanyWithCeoListQueryHandler : QueryHandlerBase<GetCompanyWithCeoListQuery, IList<CompanyCeoModel>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyWithCeoListQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public override IList<CompanyCeoModel> Handle(GetCompanyWithCeoListQuery query)
        {
            return _companyRepository.GetAll().Select(x=> new CompanyCeoModel()
            {
                CompanyId = x.Id,
                CompanyName = x.Name,
                CEO = x.CEO
            }).ToList();
        }
    }
}
