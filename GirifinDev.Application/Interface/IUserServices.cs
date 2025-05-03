using GirifinDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Application.Interface
{
    public interface IUserServices
    { 
        bool GetUserForId(int id);
        public _User IsExistUser(string email,string password);
        int RegisterUser(_User user);
        IEnumerable<_User> GetAllUser();
        void Save();
    }
}
