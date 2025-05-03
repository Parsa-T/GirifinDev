using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GirifinDev.Pages.Admin.UserPanel
{
    public class DeleteModel : PageModel
    {
        IUserServices _userServices;
        GirifinDevContext _context;
        public DeleteModel(IUserServices userServices,GirifinDevContext context)
        {
            _userServices = userServices;
            _context = context;
        }
        [BindProperty]
        public _User DeleteUser { get; set; }
        public void OnGet(int id)
        {
            DeleteUser = _context.Users.Where(u => u.Id == id).SingleOrDefault();
        }
        public IActionResult OnPost()
        {
            var user = _context.Users.Find(DeleteUser.Id);
            _context.Remove(user);
            _userServices.Save();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "AdminPanel", "UserPanel", user.Id + ".jpg");
            string filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "AdminPanel", "UserPanel", user.Id + ".png");
            if (System.IO.File.Exists(filePath2))
            {
                System.IO.File.Delete(filePath2);
            }
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            return RedirectToPage("index");
        }
    }
}
