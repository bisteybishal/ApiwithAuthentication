using BlogProject.Models;
using BlogProjects_Models.DTO;
using BlogProjects_Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Service
{
    public class UserDetailServices : IUserDetailServices
    {
        private readonly IUserDetailRepository _userDetailRepository;

        public UserDetailServices(IUserDetailRepository userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }
        public IEnumerable<UserDetail> GetAll()
        {
            return _userDetailRepository.GetAll().ToList();
        }
        public int GetUserdetailIdByUserId(string userId)
        {
            var userdetail = _userDetailRepository.GetAll().Where(x => x.UserId == userId);
            return userdetail.FirstOrDefault().Id;
        }

        public UserDetail GetUserDetails(int Id)
        {
            return _userDetailRepository.GetUserDetail(Id).Where(x => x.Id == Id).FirstOrDefault();
        }
        public void Add(UserDetail entity)
        {
            _userDetailRepository.Add(entity);
            
        }

        public void Delete(int Id)
        {
            try
            {
                var userdetail = GetUserDetails(Id);
                _userDetailRepository.Delete(userdetail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(UserDetailDto userDetaildto)
        {
            try
            {
                var detail = GetUserDetails(userDetaildto.Id);
                detail.Name = userDetaildto.Name;
                detail.Address = userDetaildto.Address;
                detail.Age = userDetaildto.Age;
                detail.Gender = userDetaildto.Gender;
                detail.Qualification = userDetaildto.Qualification;
                detail.PhoneNumber = userDetaildto.PhoneNumber;

                _userDetailRepository.Update(detail);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
