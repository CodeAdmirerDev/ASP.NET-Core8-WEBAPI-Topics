using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SecurityTypesInASPNETCoreWebAPI.Models
{
    [Index(nameof(Email), Name= "Index_Email",IsUnique= true)]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage ="First name is required")]
        [StringLength(50, ErrorMessage ="First Name cannot exceed 50 chars")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 chars")]
        public string LastName { get; set; }

        public string Department { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 chars")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PasswordHash is required")]
        public byte[] PasswordHash { get; set; }
        [Required(ErrorMessage = "PasswordSalt is required")]
        public byte[] PasswordSalt { get; set; }



    }
}
