using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]

    public class CommonController : ControllerBase
    {
       
       protected string GetCurrentUserId()
        {
            var identity = User.Identity as ClaimsIdentity;
            return identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
        } 
    }
}
