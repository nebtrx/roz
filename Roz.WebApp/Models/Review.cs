using System.ComponentModel.DataAnnotations.Schema;
using Roz.Data;

namespace Roz.WebApp.Models
{
    [Table("Reviews",Schema = "Domain")] // Table name
    public class Review : EntityWithKeyConcurrentlySafe<int>
    {
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public string ReviewText { get; set; }

        // This will keep track of the book this review belong too
        public virtual Book Book { get; set; }

    }

    public class ReviewVM
    {
        public long Id { get; set; }

        public int BookID { get; set; }
        public string ReviewText { get; set; }

        public BookVM Book { get; set; }

        public byte[] RowVersion { get; set; }
    }
}