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
    public class CategoryRepository : ICategoryRepository
    {
        GirifinDevContext _context;
        public CategoryRepository(GirifinDevContext context)
        {
            _context = context;
        }
        public void AddCategory(_CategoryProject categoryProject)
        {
            _context.Add(categoryProject);
        }

        public IEnumerable<_CategoryProject> GetAllCategory()
        {
            return _context.CategoryProjects;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
