using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCD1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15),MinLength(3)]
        public string Name { get; set; }

        [Range(10,30)]
        public int Age {  get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        public string Email { get; set; }

        [Display(Name = "Department")]
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
