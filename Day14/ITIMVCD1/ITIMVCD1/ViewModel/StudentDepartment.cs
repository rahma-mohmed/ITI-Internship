using ITIMVCD1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITIMVCD1.ViewModel
{
    public class StudentDepartment
    {
        public Student _student { get; set; }
        public Department _department { get; set; }
    }
}
