﻿using System.ComponentModel.DataAnnotations;

namespace SecurityTypesInASPNETCoreWebAPI.Models.DTO
{
    public class EmpLoginDTO
    {

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 chars")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, ErrorMessage = "Password cannot exceed 10 chars and min 6", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,10}$", ErrorMessage = "Password should contain atleast one upper case, one lower case and one digit")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
