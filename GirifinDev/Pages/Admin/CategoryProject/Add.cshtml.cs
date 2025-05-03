using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GirifinDev.Pages.Admin.CategoryProject
{
    public class AddModel : PageModel
    {
        ICategoryServices _categoryServices;
        public AddModel(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [BindProperty]
        public _CategoryProject AddCategory { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var c = new _CategoryProject()
            {
                Title=AddCategory.Title,
            };
            _categoryServices.RegisterCategory(c);
            _categoryServices.Save();
            return RedirectToPage("index");
        }
    }
}
