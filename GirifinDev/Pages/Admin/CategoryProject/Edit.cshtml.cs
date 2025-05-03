using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GirifinDev.Pages.Admin.CategoryProject
{
    public class EditModel : PageModel
    {
        ICategoryServices _categoryServices;
        GirifinDevContext _context;
        public EditModel(ICategoryServices categoryServices,GirifinDevContext context)
        {
            _categoryServices = categoryServices;
            _context = context;
        }
        [BindProperty]
        public _CategoryProject EditCategory { get; set; }
        public void OnGet(int id)
        {
            EditCategory = _context.CategoryProjects.Where(c=>c.Id==id).Select(s=> new _CategoryProject()
            {
                Id = s.Id,
                Title = s.Title,
            }).SingleOrDefault();
        }
        public IActionResult OnPost()
        {
            var c = _context.CategoryProjects.Find(EditCategory.Id);
            c.Title = EditCategory.Title;
            _categoryServices.Save();
            return RedirectToPage("index");
        }
    }
}
