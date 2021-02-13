using GJ.CQRSCore.Validation;

namespace GJ.CQRSCore.Interfaces
{
    public interface IValidator<T>
    {
        ValidationResults Validate(ValidationResults results, T validatableObject);
    }
}
