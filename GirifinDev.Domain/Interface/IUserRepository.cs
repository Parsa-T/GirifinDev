using GirifinDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Domain.Interface
{
    public interface IUserRepository
    {
        IEnumerable<_User> GetAllUser();
        public _User IsExistUser(string email , string password);
        _User GetById(int id);
        void AddUser(_User user);
        void UpdateUser(_User user);
        void Save();

    }
}
