using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GirifinDev.Pages.Admin.PageComment
{
    public class DeleteModel : PageModel
    {
        GirifinDevContext _context;
        IProjectServices _projectServices;
        public DeleteModel(GirifinDevContext context,IProjectServices projectServices)
        {
            _context = context;
            _projectServices = projectServices;
        }
        [BindProperty]
        public _PageComment DeleteComment { get; set; }
        public void OnGet(int id)
        {
            DeleteComment = _context.PageComments.Where(p=>p.Id==id).SingleOrDefault();
        }
        public IActionResult OnPost()
        {
            var pc = _context.PageComments.Find(DeleteComment.Id);
            _context.Remove(pc);
            _projectServices.Save();
            return RedirectToPage("index");
        }
    }
}
