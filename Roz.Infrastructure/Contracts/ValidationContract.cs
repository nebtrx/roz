using Roz.Infrastructure.Services;

namespace Roz.Infrastructure.Contracts
{
    public class ValidationContract
    {
        private readonly ErrorList _errors;

        public ValidationContract(ErrorList errors)
        {
            _errors = errors ?? new ErrorList();
        }

        public ErrorList Errors
        {
            get { return _errors; }
        }

        public bool IsValid
        {
            get { return _errors.GetErrors().Count == 0; }
        }

        public ValidationContract Condition(bool condition, string conditionName, string message = null)
        {
            var errMsg = message ?? "Condition: [" + conditionName + "] was violated";

            if (!condition)
                _errors.AddError(conditionName, errMsg);

            return this;
        }

        public ValidationContract ElementNotNull(object o, string paramName, string message = null)
        {
            var errMsg = message ?? paramName + " cannot be null";
            
            if (o == null)
                _errors.AddError(paramName, errMsg);

            return this;
        }

        public ValidationContract ElementNotNullOrEmpty(string s, string paramName, string message = null)
        {
            var errMsg = message ?? paramName + " cannot be null or empty";

            if (string.IsNullOrEmpty(s))
                _errors.AddError(paramName, errMsg);

            return this;
        }

        public ValidationContract ElementGreaterThanZero(double number, string paramName, string message = null)
        {
            var errMsg = message ?? paramName + " cannot be zero or negative";

            if (number <= 0)
                _errors.AddError(paramName, errMsg);

            return this;
        }

        public ValidationContract ElementGreaterThanZero(long number, string paramName, string message = null)
        {
            var errMsg = message ?? paramName + " cannot be zero or negative";

            if (number <= 0)
                _errors.AddError(paramName, errMsg);

            return this;
        }
    }
}
