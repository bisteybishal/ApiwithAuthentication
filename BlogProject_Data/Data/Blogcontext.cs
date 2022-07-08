
using BlogProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogProject_Data.Data
{
    public class Blogcontext : IdentityDbContext 
    {
         public Blogcontext(DbContextOptions<Blogcontext> options) : base(options)
        {

        }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
        }
       
    }
}
