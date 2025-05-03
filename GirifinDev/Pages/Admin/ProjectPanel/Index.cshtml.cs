using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GirifinDev.Pages.Admin.ProjectPanel
{
    public class IndexModel : PageModel
    {
        GirifinDevContext _context;
        public IndexModel(GirifinDevContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IEnumerable<_Project> GetAllProject { get; set; }
        public void OnGet()
        {
            GetAllProject = _context.Projects.Include(p=>p.CategoryProject);
        }
    }
}
