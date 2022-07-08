using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        [Required]
        public string Heading { get; set; }
        [Required]
        public string Content { get; set; }
        public int NumberofLikes { get; set; }
        public int UserDetailId { get; set; }
        public UserDetail UserDetail { get; set; }
      }
}
