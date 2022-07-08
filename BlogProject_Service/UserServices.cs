using BlogProject.Models;
using BlogProjects_Models.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace BlogProject_Service
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager <IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

       
        public UserServices(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task CreateUser(SignUpDto dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };
           var result=await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Unsucessful");
            }

        }
       
        public async Task<UserDto> Login(SignUpDto model)
        {
            var userdto = new UserDto();
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, 
                    isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                var user = await _userManager.FindByNameAsync(model.Email);
                userdto.Email = user.Email;
                userdto.Id = user.Id;
                var token = GenerateToken(userdto);
                userdto.Token = token;
            }
            else
            {
                throw new Exception("Unsucessful");
            }
            return userdto;

        }
        public string GenerateToken(UserDto user)
        {

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Email, user.Email),
             new Claim(ClaimTypes.Name, user.Id)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return  tokenHandler.WriteToken(token) ;

        }
       
    }
}
