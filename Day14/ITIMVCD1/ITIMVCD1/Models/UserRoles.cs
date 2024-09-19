using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCD1.Models
{
    public class UserRoles
    {
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public Role Roles { get; set; }
    }
}
