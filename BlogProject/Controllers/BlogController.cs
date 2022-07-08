
using BlogProject.Models;
using BlogProject_Service;
using BlogProjects_Models.DTO;
using BlogProjects_Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : CommonController
    {
        private readonly IBlogServices _blogServices;
        private readonly IUserDetailServices _userDetailServices;

     public BlogController(IBlogServices blogServices, IUserDetailServices userDetailServices)
        {
            _blogServices = blogServices;
            _userDetailServices = userDetailServices;
        }

        [HttpGet]
        [Route("GetBlogsById")]
        public  async Task<IActionResult> GetBlogsById(int blogId)
        {
            try
            {
                var blog =  _blogServices.GetBlog(blogId);
                if (blog != null)
                {
                    return Ok(blog);
                }
                return StatusCode(StatusCodes.Status404NotFound,
                        "Invalid Blog Id");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Receving data from Database");
            }   
                
        }
       [HttpGet]
        [Route("GetUserBlogs")]
        public async Task<IActionResult> GetUserBlogs()
        {
            try
            {
                var user = GetCurrentUserId();
                var id = _userDetailServices.GetUserdetailIdByUserId(GetCurrentUserId());
                var blog = _blogServices.GetAllBlogsByUserDetailId(id);
                if (blog != null)
                {
                    return Ok(blog);
                }
                return StatusCode(StatusCodes.Status404NotFound,
                        "Invalid UserId ");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Receving data from Database");
            }
        }
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            try
            {
                var blog= _blogServices.GetAll();
                return Ok(blog);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Receving data from Database");

            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Blog blog)
        {
            try
            {
                blog.UserDetailId = _userDetailServices.GetUserdetailIdByUserId(GetCurrentUserId());
                                 _blogServices.Add(blog);
                return (StatusCode(StatusCodes.Status201Created, "Sucessfully created"));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Receving data from Database");

            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BlogDto blog)
        {
            try
             {
                _blogServices.Update(blog);
                return Ok("Update Sucess Blog ");
            }
            catch(Exception ex)
              {
                    return StatusCode(StatusCodes.Status400BadRequest,
                       ex.Message);

                }
            
          
        }
        [HttpDelete]
        [Route("blogId")]
        public async Task<IActionResult> Delete( int blogId)
        {
            try
            {
                    _blogServices.Delete(blogId);
                    return Ok("Sucessfully Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                   ex.Message);

            }


        }
    }
}
