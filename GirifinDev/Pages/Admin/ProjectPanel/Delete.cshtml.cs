using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GirifinDev.Pages.Admin.ProjectPanel
{
    public class DeleteModel : PageModel
    {
        GirifinDevContext _context;
        IProjectServices _projectServices;
        public DeleteModel(GirifinDevContext context, IProjectServices projectServices)
        {
            _context = context;
            _projectServices = projectServices;
        }
        [BindProperty]
        public _Project DeleteProject { get; set; }
        public void OnGet(int id)
        {
            DeleteProject = _context.Projects.Where(p => p.Id == id).Include(c => c.CategoryProject).SingleOrDefault();
        }
        public IActionResult OnPost()
        {
            var pro = _context.Projects.Find(DeleteProject.Id);
            _context.Remove(pro);
            _projectServices.Save();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "AdminPanel", "ProjectPanel",
                pro.Id + ".jpg");
            string filePath2 = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "AdminPanel", "ProjectPanel",
                    pro.Id + ".png");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            if (System.IO.File.Exists(filePath2))
            {
                System.IO.File.Delete(filePath2);
            }
            return RedirectToPage("index");
        }
    }
}
