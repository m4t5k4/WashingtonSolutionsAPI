using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        [NotMapped]
        public string Token { get; set; }

        //Relations
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<TeamUser>? TeamUsers { get; set; }
        public Group? Group { get; set; }
        public int? GroupID { get; set; }
        public File? UserPicture { get; set; }
        public int? UserPictureID { get; set; }
    }
}
