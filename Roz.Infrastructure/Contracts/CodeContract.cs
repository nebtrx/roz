using Roz.Infrastructure.Services;

namespace Roz.Infrastructure.Contracts
{
    public class CodeContract
    {
        public static ValidationContract Validates()
        {
            return new ValidationContract(new ErrorList());
        }

        public static RequisiteContract Requires()
        {
            return new RequisiteContract();
        }
    }
}