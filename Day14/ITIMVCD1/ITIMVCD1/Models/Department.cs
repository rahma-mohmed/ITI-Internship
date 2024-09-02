using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCD1.Models
{
    public class Department
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }  

        public virtual ICollection<Student> Students { get; set; }
    }
}
