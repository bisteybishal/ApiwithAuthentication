using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjects_Models.DTO
{
    public class UserDetailDto

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Qualification Qualification { get; set; }
        public string PhoneNumber { get; set; }

    }
}
