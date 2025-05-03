using GirifinDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Application.Interface
{
    public interface IProjectServices
    {
        int RegisterProject(_Project project);
        int CountProject();
        void Save();
    }
}
