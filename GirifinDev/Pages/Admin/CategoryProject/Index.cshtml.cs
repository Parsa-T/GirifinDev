using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GirifinDev.Pages.Admin.CategoryProject
{
    public class IndexModel : PageModel
    {
        ICategoryServices _categoryServices;
        public IndexModel(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [BindProperty]
        public IEnumerable<_CategoryProject> GetAllCategory { get; set; }
        public void OnGet()
        {
            GetAllCategory = _categoryServices.GetAllCategory();
        }
    }
}
