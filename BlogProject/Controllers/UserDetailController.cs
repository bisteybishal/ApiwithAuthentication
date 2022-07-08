using BlogProject.Models;
using BlogProject_Service;
using BlogProjects_Models.DTO;
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
    public class UserDetailController : CommonController
    {
        private readonly IUserDetailServices _userDetailServices;

        public UserDetailController(IUserDetailServices userDetailServices)
        {
           _userDetailServices = userDetailServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var details = _userDetailServices.GetAll();
                return Ok(details);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserDetail(int id)
        {
            try
            {
                var detail = _userDetailServices.GetUserDetails(id);
                if (detail != null)
                {
                    return Ok(detail);
                }
                return StatusCode(StatusCodes.Status404NotFound, "Result Not found");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Data Not found");
            }
        }



        [HttpPost]
        public async Task<IActionResult> post([FromBody] UserDetail detail)
        {
            try
            {
                
                detail.UserId = GetCurrentUserId();
                 _userDetailServices.Add(detail);
                return StatusCode(StatusCodes.Status201Created,"Successfully Created");

            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error retirving data from Db");
            }
        }
        [HttpPut]
        public async Task<IActionResult> put ([FromBody]  UserDetailDto detailDto)
        {
            try
            {
                _userDetailServices.Update(detailDto);
                return Ok("Updated");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromBody] int Id)
        //{
        //    try
        //    {
        //        _userDetailServices.Delete(Id);
        //        return Ok("deleted");
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            try
            {
                _userDetailServices.Delete(id);
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
