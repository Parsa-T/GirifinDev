using GirifinDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Application.Interface
{
    public interface ICategoryServices
    {
        IEnumerable<_CategoryProject> GetAllCategory();
        int RegisterCategory(_CategoryProject categoryProject);
        void Save();
    }
}
