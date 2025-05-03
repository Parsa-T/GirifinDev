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
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository _repository;
        public CategoryServices(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<_CategoryProject> GetAllCategory()
        {
           return _repository.GetAllCategory();
        }

        public int RegisterCategory(_CategoryProject categoryProject)
        {
            _repository.AddCategory(categoryProject);
            return categoryProject.Id;
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}
