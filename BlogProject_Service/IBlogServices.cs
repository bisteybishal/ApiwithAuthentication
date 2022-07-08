using BlogProject.Models;
using BlogProjects_Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject_Service
{
    public interface IBlogServices
    {
       IEnumerable<Blog> GetAll();
        IEnumerable<Blog> GetAllBlogsByUserDetailId(int userdetailId);
        Blog GetBlog(int blogId);
        void Add(Blog entity);
       void Update(BlogDto blogdto);
       void Delete(int blogId);
    }
}