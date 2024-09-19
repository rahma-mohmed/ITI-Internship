using System.ComponentModel.DataAnnotations;

namespace ITIMVCD1.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(30, 60)]
        public int Duration { get; set; }
    }
}
