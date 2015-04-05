using System.Collections.Generic;

namespace Roz.Infrastructure.Services
{
    public class Result
    {
        private readonly ErrorList _errorList;

        public Result()
            : this(null)
        {
        }

        public Result(ErrorList errorList)
        {
            _errorList = errorList ?? new ErrorList();
        }

        /// <summary>
        /// Stores any erros that happnened on the excution of the service
        /// Errors are stored in the following way:
        /// (field or key) => (list of errors for a given field or key)
        /// </summary>
        public Dictionary<string, IEnumerable<string>> Errors
        {
            get { return _errorList.GetErrors(); }
        }

        /// <summary>
        /// Determines if the operation was sucessul or not based on the amount
        /// of error in Errors
        /// </summary>
        public bool Success
        {
            get { return Errors.Count == 0; }
        }

        public void AddError(string field, string errorMessage)
        {
            _errorList.AddError(field, errorMessage);
        }
    }
}
