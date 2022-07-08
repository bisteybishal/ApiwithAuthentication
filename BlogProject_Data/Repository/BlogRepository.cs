using BlogProject.Models;
using BlogProject_Data.Data;
using BlogProjects_Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Data.Repository
{
  public  class BlogRepository:IBlog
    {
        private readonly Blogcontext _context;

        public BlogRepository(Blogcontext context)
        {
            _context = context;
        }
         public IQueryable<Blog> GetAll()
        {
            return _context.Blogs.AsQueryable();//select * from blogs
        }

        public IQueryable<Blog> GetBlog(int blogId)
        {
            return _context.Blogs.Where(x => x.BlogId == blogId);
        }

        public IQueryable<Blog> GetBlogsbyUserDetailId(int userdetailId)
        {
            return _context.Blogs.Where(x => x.UserDetailId == userdetailId);
        }
        public void Add(Blog entity)
        {
            _context.Blogs.Add(entity);
            _context.SaveChanges();

        }

      public void Update(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }
        public void Delete(Blog blog)
        {
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }
    }
}
