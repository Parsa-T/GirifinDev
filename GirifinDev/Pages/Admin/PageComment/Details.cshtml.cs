using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GirifinDev.Pages.Admin.PageComment
{
    public class DetailsModel : PageModel
    {
        GirifinDevContext _context;
        public DetailsModel(GirifinDevContext context)
        {
            _context = context;
        }
        [BindProperty]
        public _PageComment DetailsComment { get; set; }
        public void OnGet(int id)
        {
            DetailsComment = _context.PageComments.Where(c=>c.Id==id).SingleOrDefault();
        }
    }
}
