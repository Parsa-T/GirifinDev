using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GirifinDev.Pages.Admin.CategoryProject
{
    public class DeleteModel : PageModel
    {
        ICategoryServices _categoryServices;
        GirifinDevContext _context;
        public DeleteModel(ICategoryServices categoryServices,GirifinDevContext context)
        {
            _categoryServices = categoryServices;
            _context = context;
        }
        [BindProperty]
        public _CategoryProject DeleteCategory { get; set; }
        public void OnGet(int id)
        {
            DeleteCategory = _context.CategoryProjects.Where(c => c.Id == id).SingleOrDefault();
        }
        public IActionResult OnPost()
        {
            var c = _context.CategoryProjects.Find(DeleteCategory.Id);
            _context.Remove(c);
            _categoryServices.Save();
            return RedirectToPage("index");
        }
    }
}
