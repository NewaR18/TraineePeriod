using System.ComponentModel.DataAnnotations;

namespace masterdetailswithtabs.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50,ErrorMessage="Enter valid name")]
        public string Name { get; set; }
        [Range(18,100)]
        public short Age { get; set; }
        [StringLength(50,ErrorMessage ="Enter valid address")]
        public string Address { get; set; }
        [StringLength(10)]
        public string PhoneNo { get; set; }
        public virtual List<Books> books { get; set; } =new List<Books>();
    }
}
