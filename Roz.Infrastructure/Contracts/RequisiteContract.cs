using System;

namespace Roz.Infrastructure.Contracts
{
    public class RequisiteContract
    {
        public RequisiteContract Condition(bool condition, string message = null)
        {
            var errMsg = message ?? "Condition violated";

            if (!condition)
                throw new InvalidOperationException(errMsg);

            return this;
        }

        public RequisiteContract Condition<TException>(bool condition, string message = null) where TException : Exception, new()
        {
            var errMsg = message ?? "Condition: was violated";

            if (!condition)
                TriggerException<TException>(errMsg);
            return this;
        }

        public RequisiteContract ElementNotNull(object obj, string paramName = null, string message = null)
        {
            var errMsg = message ?? paramName?? "Value" + " cannot be null";

            if (obj == null)
            {
                if (String.IsNullOrWhiteSpace(paramName))
                    throw new ArgumentNullException(message, (Exception) null);

                throw new ArgumentNullException(paramName, errMsg);
            }
            return this;
        }

        public RequisiteContract ElementNotNull<TException>(object obj, string message = null) where TException : Exception, new()
        {
            var errMsg = message ?? "Value cannot be null";

            if (obj == null)
                TriggerException<TException>(errMsg);
            return this;
        }

        public RequisiteContract ElementNotNullOrEmpty(string s, string paramName = null, string message = null)
        {
            var errMsg = message ?? paramName ?? "Value" + " cannot be null or empty";

            if (string.IsNullOrEmpty(s))
            {
                if (String.IsNullOrWhiteSpace(paramName))
                    throw new ArgumentNullException(message, (Exception)null);

                throw new ArgumentNullException(paramName, errMsg);
            }
            return this;
        }

        public RequisiteContract ElementNotNullOrEmpty<TException>(string s, string message = null) where TException : Exception, new()
        {
            var errMsg = message ?? "Value cannot be null or empty";

            if (string.IsNullOrEmpty(s))
                TriggerException<TException>(errMsg);
            return this;
        }

        public RequisiteContract ElementGreaterThanZero(double number, string paramName = null, string message = null)
        {
            var errMsg = message ?? paramName?? "Value" + " cannot be zero or negative";

            if (number <= 0)
                throw new ArgumentOutOfRangeException(paramName, errMsg);
            return this;
        }

        public RequisiteContract ElementGreaterThanZero<TException>(double number, string message = null) 
            where TException : Exception, new()
        {
            var errMsg = message ?? "Value cannot be zero or negative";

            if (number <= 0)
                TriggerException<TException>(errMsg);
            return this;
        }

        public RequisiteContract ElementGreaterThanZero(long number, string paramName, string message = null)
        {
            var errMsg = message ?? paramName + " cannot be zero or negative";

            if (number <= 0)
                throw new ArgumentOutOfRangeException(paramName, errMsg);
            return this;
        }

        public RequisiteContract ElementGreaterThanZero<TException>(long number, string message = null)
            where TException : Exception, new()
        {
            var errMsg = message ?? "Value cannot be zero or negative";

            if (number <= 0)
                TriggerException<TException>(errMsg);
            return this;
        }

        private static void TriggerException<TException>(string errMsg) where TException : Exception, new()
        {
            var ex = new TException();
            typeof(TException).GetField("_message").SetValue(ex, errMsg);
            throw ex;
        }

    }
}