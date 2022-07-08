using BlogProject.Models;
using BlogProjects_Models.DTO;
using BlogProjects_Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogProject_Service
{
    public class BlogServices : IBlogServices
    {
        private readonly IBlog _blog;

        public BlogServices(IBlog blog)
        {
            _blog = blog;
        }

        public IEnumerable<Blog> GetAll()
        {
            return _blog.GetAll().Include(x=>x.UserDetail).ToList();
        }

        public IEnumerable<Blog> GetAllBlogsByUserDetailId(int userdetailId)
        {
            return _blog.GetBlogsbyUserDetailId(userdetailId).Include(x => x.UserDetail).ThenInclude(x=>x.User);
        }

        public Blog GetBlog(int blogId)
        {
            return _blog.GetBlog(blogId).FirstOrDefault();
        }
        public void Add(Blog entity)
        {
            _blog.Add(entity);
        }

        public void Delete(int blogId)
        {
            try
            {
                var blog = GetBlog(blogId);
                _blog.Delete(blog);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Update(BlogDto blogdto)
        {
            try
            {
                var blog = GetBlog(blogdto.Id);
                blog.Heading = blogdto.Heading;
                blog.Content = blogdto.Content;
                _blog.Update(blog);
            }
            catch
            {
                throw;
            }

        }


    }
}
