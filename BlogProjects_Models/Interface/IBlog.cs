using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogProjects_Models.Interface 
{ 
    public interface IBlog
    {
        IQueryable<Blog> GetAll();
        IQueryable<Blog> GetBlogsbyUserDetailId(int userdetailId);
        IQueryable<Blog> GetBlog(int blogId);
        void Add(Blog entity);
        void Update(Blog blog);
        void Delete(Blog blog);

    }
}
