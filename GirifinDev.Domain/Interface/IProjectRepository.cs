using GirifinDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Domain.Interface
{
    public interface IProjectRepository
    {
        void AddProject(_Project project);
        int ProjectCount();
        void Save();
    }
}
