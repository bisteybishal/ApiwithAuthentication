
using BlogProject.Models;
using BlogProject_Data.Data;
using BlogProjects_Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject_Data.Repository
{
    public class UserDetailRepo : IUserDetailRepository
    {
        private readonly Blogcontext _context;

        public UserDetailRepo(Blogcontext context)
        {
            _context = context;
        }
        public IQueryable<UserDetail> GetAll()
        {
            return _context.UserDetails.AsQueryable();
        }

        public IQueryable<UserDetail> GetUserDetail(int UserId)
        {
            return _context.UserDetails.Where(x => x.Id == UserId);
        }
        public void Add(UserDetail entity)
        {
            _context.UserDetails.Add(entity);
            _context.SaveChanges();
        }
        public void Update(UserDetail userDetail)
        {
            _context.UserDetails.Update(userDetail);
            _context.SaveChanges();
        }
        public void Delete(UserDetail entity)
        {
            _context.UserDetails.Remove(entity);
            _context.SaveChanges();
        }
    }
}