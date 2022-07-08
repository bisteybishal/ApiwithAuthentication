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
    public class Account : ControllerBase
    {
        private readonly IUserServices _userServices;

        public Account(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]SignUpDto dto)
        {
          
            try
            {
                var user = await _userServices.Login(dto);
                return StatusCode(StatusCodes.Status200OK,user);

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }

        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]SignUpDto dto)
        {

            try
            {
                await _userServices.CreateUser(dto);
                return StatusCode(StatusCodes.Status200OK, "Sucessfully created");

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }

        }

    }
}
