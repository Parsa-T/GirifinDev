using GirifinDev.Application.DTO;
using GirifinDev.Infra.Data.Context;

namespace GirifinDev.Services
{
    public class ProjectQueriServices : IProjectQueriServices
    {
        GirifinDevContext _context;
        public ProjectQueriServices(GirifinDevContext context)
        {
            _context = context;
        }

        public List<ShowCategoryProjectDTO> GetAllCategory()
        {
            var cg = (from g in _context.CategoryProjects
                      select new ShowCategoryProjectDTO()
                      {
                          Id = g.Id,
                          Title = g.Title,
                      }).ToList();
            return cg;
        }

        public List<ProjectShowDTO> GetprojectByCategoryId(int categoryId)
        {
            var result = (from pr in _context.Projects
                          where pr.CategoryId == categoryId
                          select new ProjectShowDTO()
                          {
                              Description = pr.Description,
                              ImageUrl = pr.ImageUrl,
                              Link = pr.Link,
                              Name = pr.Name,
                          }).ToList();
            return result;
        }

        public List<ProjectShowDTO> ShowAllProject()
        {
            var pro = (from pr in _context.Projects
                       select new ProjectShowDTO()
                       {
                           Description = pr.Description,
                           Id = pr.Id,
                           ImageUrl = pr.ImageUrl,
                           Link = pr.Link,
                           Name = pr.Name,
                       }).ToList();
            return pro;
        }

        public ShowProjectDTO ShowProject()
        {
            var pro = (from ca in _context.CategoryProjects
                       select new ShowCategoryProjectDTO()
                       {
                           Title = ca.Title,
                           Id = ca.Id,
                       }).ToList();
            return new ShowProjectDTO
            {
                categoryProjectDTOs = pro
            };
        }
    }
}
