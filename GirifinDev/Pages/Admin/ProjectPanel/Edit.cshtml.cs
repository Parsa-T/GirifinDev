using GirifinDev.Application.DTO;
using GirifinDev.Application.Interface;
using GirifinDev.Infra.Data.Context;
using GirifinDev.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GirifinDev.Pages.Admin.ProjectPanel
{
    public class EditModel : PageModel
    {
        GirifinDevContext _context;
        IProjectServices _projectServices;
        public EditModel(GirifinDevContext context,IProjectServices projectServices)
        {
            _context = context;
            _projectServices = projectServices;
        }
        [BindProperty]
        public ShowProjectDTO EditProject { get; set; }
        public void OnGet(int id)
        {
            EditProject = _context.Projects.Where(p => p.Id == id).Select(s => new ShowProjectDTO()
            {
                CategoryId = s.CategoryId,
                Description = s.Description,
                Link = s.Link,
                Name = s.Name,
                Id = s.Id
            }).SingleOrDefault();
        }
        public IActionResult OnPost()
        {
            var pro = _context.Projects.Find(EditProject.Id);
            pro.CategoryId = EditProject.CategoryId;
            pro.Description = EditProject.Description;
            pro.Link = EditProject.Link;
            pro.Name = EditProject.Name;
            _projectServices.Save();
            if (EditProject.imgUp?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "AdminPanel", "ProjectPanel",
                    pro.Id + Path.GetExtension(EditProject.imgUp.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    EditProject.imgUp.CopyTo(stream);
                }
                pro.ImageUrl = pro.Id + Path.GetExtension(EditProject.imgUp.FileName);
                _projectServices.Save();
            }
            return RedirectToPage("index");
        }
    }
}
