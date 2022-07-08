using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjects_Models.Interface
{
   public interface IUserDetailRepository
    {
        IQueryable<UserDetail> GetAll();
        IQueryable<UserDetail> GetUserDetail(int UserId);
        void Add(UserDetail entity);
        void Update(UserDetail userDetail);
        void Delete(UserDetail entity);
    }
}
