using GJ.CQRSCore.Example.Data.Interfaces;
using GJ.CQRSCore.Example.Models.Commands;
using GJ.CQRSCore.Interfaces;
using GJ.CQRSCore.Validation;
using System;
using System.Linq;

namespace GJ.CQRSCore.Example.BusinessLogic.Validator
{
    public class AddCompanyWithOfficeCommandValidator : IValidator<AddCompanyWithOfficeCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IOfficeRepository _officeRepository;
        public AddCompanyWithOfficeCommandValidator(ICompanyRepository companyRepository, IOfficeRepository officeRepository)
        {
            _companyRepository = companyRepository;
            _officeRepository = officeRepository;
        }

        public ValidationResults Validate(ValidationResults results, AddCompanyWithOfficeCommand validatableObject)
        {
            results = ValidateNoNullOrEmptyValues(results, validatableObject);
            results = ValidateCompanyNameDoesntExist(results, validatableObject);
            results = ValidateAddressAlreadyExists(results, validatableObject);
            return results;
        }

        private ValidationResults ValidateAddressAlreadyExists(ValidationResults results, AddCompanyWithOfficeCommand validatableObject)
        {
            if (_officeRepository.GetAll().Any(x => x.Street == validatableObject.Street && x.HouseNumber == validatableObject.HouseNumber && x.City == validatableObject.City))
            {
                results.AddValidationResult(nameof(validatableObject.CompanyName), "The adress already exists in the database.");
            }
            return results;
        }

        private ValidationResults ValidateCompanyNameDoesntExist(ValidationResults results, AddCompanyWithOfficeCommand validatableObject)
        {
            if (_companyRepository.GetAll().Any(x => x.Name == validatableObject.CompanyName))
            {
                results.AddValidationResult(nameof(validatableObject.CompanyName), "{0} already exists.");
            }
            return results;
        }

        private static ValidationResults ValidateNoNullOrEmptyValues(ValidationResults results, AddCompanyWithOfficeCommand validatableObject)
        {
            results.ValidateNotNullOrEmpty(validatableObject.CompanyName, nameof(validatableObject.CompanyName));
            results.ValidateNotNullOrEmpty(validatableObject.CEO, nameof(validatableObject.CEO));
            results.ValidateNotNullOrEmpty(validatableObject.BuildingName, nameof(validatableObject.BuildingName));
            results.ValidateNotNullOrEmpty(validatableObject.Street, nameof(validatableObject.Street));
            results.ValidateNotNull(validatableObject.HouseNumber, nameof(validatableObject.HouseNumber));
            results.ValidateNotNullOrEmpty(validatableObject.City, nameof(validatableObject.City));

            return results;
        }
    }
}
