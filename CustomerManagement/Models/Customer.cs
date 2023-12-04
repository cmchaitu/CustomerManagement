using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string? Email { get; set; }
        public string? Address { get; set; }
            [Required]
        [MaxLength(10,ErrorMessage ="Phone Number should be 10 digits") ]
        [MinLength(10, ErrorMessage = "Phone Number should be 10 digits")]
            public string? Phone { get; set; }
    }
}
