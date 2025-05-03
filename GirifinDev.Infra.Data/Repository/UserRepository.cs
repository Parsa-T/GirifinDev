using GirifinDev.Application.DTO;
using GirifinDev.Domain.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private GirifinDevContext _context;
        public UserRepository(GirifinDevContext context)
        {
            _context = context;
        }
        public void AddUser(_User user)
        {
            _context.Add(user);
        }

        public IEnumerable<_User> GetAllUser()
        {
            return _context.Users;
        }

        public _User GetById(int id)
        {
             return _context.Users.Find(id);
        }

        public _User IsExistUser(string email, string password)
        {
           return _context.Users.SingleOrDefault(u=>u.Email==email&&u.Password==password);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateUser(_User user)
        {
            _context.Users.Entry(user).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
