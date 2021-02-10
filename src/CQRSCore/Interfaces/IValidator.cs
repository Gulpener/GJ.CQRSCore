using CQRSCore.Validation;

namespace CQRSCore.Interfaces
{
    public interface IValidator<T>
    {
        ValidationResults Validate(ValidationResults results, T validatableObject);
    }
}
