using GirifinDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Domain.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<_CategoryProject> GetAllCategory();
        void AddCategory(_CategoryProject categoryProject);
        void Save();
    }
}
