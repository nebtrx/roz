using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using Roz.Data;

namespace Roz.WebApp.Models
{
    [Table("Books", Schema = "Domain")] // Table name
    public class Book:EntityWithKeyConcurrentlySafe<int>
    {
        public string BookName { get; set; }
        public string ISBN { get; set; }

        // This is to maintain the many reviews associated with a book entity
        public virtual ICollection<Review> Reviews { get; set; }
    }

    public class BookVM
    {
        public long Id { get; set; }

        public string BookName { get; set; }
        public string ISBN { get; set; }

        public List<ReviewVM> Reviews { get; set; }

        public byte[] RowVersion { get; set; }
    }
}