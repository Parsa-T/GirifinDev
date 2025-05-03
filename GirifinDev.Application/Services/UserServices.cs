using GirifinDev.Application.Interface;
using GirifinDev.Domain.Interface;
using GirifinDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Application.Services
{
    public class UserServices : IUserServices
    {
        IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<_User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public bool GetUserForId(int id)
        {
            try
            {
                _userRepository.GetById(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public _User IsExistUser(string email, string password)
        {
                var conEmail = email.ToLower().Trim();
               return _userRepository.IsExistUser(conEmail,password);
        }

        public void Save()
        {
            _userRepository.Save();
        }

        int IUserServices.RegisterUser(_User user)
        {
            _userRepository.AddUser(user);
            return user.Id;
        }
    }
}
