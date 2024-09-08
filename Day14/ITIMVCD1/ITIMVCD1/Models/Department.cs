using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCD1.Models
{
    public class Department
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [Required]  
        public string Name { get; set; }

        [Required]
        [Range(100 , 200)]
        public int Capacity { get; set; }

        public bool Statuse { get; set; }   

        public virtual ICollection<Student>? Students { get; set; }
    }
}
