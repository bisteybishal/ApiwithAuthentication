using BlogProject.Models;
using BlogProjects_Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Service
{
   public interface IUserDetailServices
    {
        IEnumerable<UserDetail> GetAll();
        int GetUserdetailIdByUserId(string userId);
        UserDetail GetUserDetails(int Id);
        void Add(UserDetail entity);
        void Update(UserDetailDto userDetaildto);
        void Delete(int Id);

    }
}
