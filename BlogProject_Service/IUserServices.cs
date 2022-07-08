using BlogProjects_Models.DTO;
using System.Threading.Tasks;

namespace BlogProject_Service
{
    public interface IUserServices
    {
        Task CreateUser(SignUpDto dto);
        Task<UserDto> Login(SignUpDto model);
    }
}