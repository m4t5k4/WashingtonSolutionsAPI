using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }

        //Relations
        public File? GroupPicture { get; set; }
        public int? GroupPictureID { get; set; }
    }
}
