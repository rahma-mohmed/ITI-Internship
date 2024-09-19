using System.ComponentModel.DataAnnotations;

namespace ITIMVCD2.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
