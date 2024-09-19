using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCD1.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Remote("EmailCheck" , "Account" , "Email already exist!!")]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Display(Name="Role")]
        public string? UserRole { get; set; }
    }
}
