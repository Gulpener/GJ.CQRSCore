using GJ.CQRSCore.Interfaces;
using GJ.CQRSCore.Validation;
using System;

namespace GJ.CQRSCore
{
    public abstract class QueryHandlerBase<T, X> : IQueryHandler<T, X> where T : IQuery
    {
        private readonly IValidator<T> _validator;
        public QueryHandlerBase()
        {

        }
        public QueryHandlerBase(IValidator<T> validator)
        {
            _validator = validator;
        }

        public X Execute(T query)
        {
            if (_validator != null)
            {
                var validationResults = _validator.Validate(new ValidationResults(), query);
                validationResults.Handle();
            }
            return Handle(query);
        }

        public abstract X Handle(T query);
    }
}
