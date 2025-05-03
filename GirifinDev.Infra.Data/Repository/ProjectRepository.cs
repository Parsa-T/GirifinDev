using GirifinDev.Domain.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Infra.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        GirifinDevContext _context;
        public ProjectRepository(GirifinDevContext context)
        {
            _context = context;
        }
        public void AddProject(_Project project)
        {
            _context.Add(project);
        }

        public int ProjectCount()
        {
            return _context.Projects.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
