using System.Collections.Generic;
using System.Linq;

namespace Roz.Infrastructure.Services
{
    public class ErrorList
    {
        public static ErrorList Empty = new ErrorList();

        private readonly Dictionary<string, List<string>> _errorList;

        public ErrorList()
        {
            _errorList = new Dictionary<string, List<string>>();
        }

        public void AddError(string field, string errorMessage)
        {
            if (!_errorList.ContainsKey(field))
            {
                _errorList.Add(field, new List<string>());
            }

            _errorList[field].Add(errorMessage);
        }

        public Dictionary<string, IEnumerable<string>> GetErrors()
        {
            return _errorList.ToDictionary<KeyValuePair<string, List<string>>, string, IEnumerable<string>>(
                pair => pair.Key, pair => pair.Value);
        }
    }
}