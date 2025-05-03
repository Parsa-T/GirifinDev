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
    public class ProjectServices : IProjectServices
    {
        IProjectRepository _repository;
        public ProjectServices(IProjectRepository repository)
        {
            _repository = repository;
        }

        public int CountProject()
        {
            return _repository.ProjectCount();
        }

        public int RegisterProject(_Project project)
        {
            _repository.AddProject(project);
            return project.Id;
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}
