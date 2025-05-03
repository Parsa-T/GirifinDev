using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GirifinDev.Pages.Admin.PageComment
{
    public class IndexModel : PageModel
    {
        GirifinDevContext _context;
        public IndexModel(GirifinDevContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IEnumerable<_PageComment> GetAllComment { get; set; }
        public void OnGet()
        {
            GetAllComment = _context.PageComments.ToList();
        }
    }
}
