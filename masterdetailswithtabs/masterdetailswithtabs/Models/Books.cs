using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace masterdetailswithtabs.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Publisher { get; set; }
        [StringLength(100)]
        public string Reference { get; set; }
        [ForeignKey("Customer")]
        public int Id { get; set; }
    }
}
