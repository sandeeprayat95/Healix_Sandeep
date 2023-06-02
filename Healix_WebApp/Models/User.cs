using System.ComponentModel.DataAnnotations;

namespace Healix_WebApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(3)]
        public string MobileCountryCode { get; set; }

        [MaxLength(20)]
        public string MobileNumber { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
