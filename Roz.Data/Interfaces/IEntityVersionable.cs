using System.ComponentModel.DataAnnotations;

namespace Roz.Data
{
    public interface IEntityVersionable
    {
        [Timestamp]
        byte[] RowVersion { get; set; }
    }
}
