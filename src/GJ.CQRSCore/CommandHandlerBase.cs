using GJ.CQRSCore.Interfaces;
using GJ.CQRSCore.Validation;

namespace GJ.CQRSCore
{
    public abstract class CommandHandlerBase<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly IValidator<T> _validator;

        public CommandHandlerBase() { }

        public CommandHandlerBase(IValidator<T> validator)
        {
            _validator = validator;
        }

        public void Execute(T command)
        {
            if (_validator != null)
            {
                var validationResults = _validator.Validate(new ValidationResults(), command);
                validationResults.Handle();
            }
            Handle(command);
        }

        public abstract void Handle(T command);
    }
}
