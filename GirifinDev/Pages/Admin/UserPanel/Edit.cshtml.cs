using GirifinDev.Application.DTO;
using GirifinDev.Application.Interface;
using GirifinDev.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GirifinDev.Pages.Admin.UserPanel
{
    public class EditModel : PageModel
    {
        IUserServices _userServices;
        GirifinDevContext _context;
        public EditModel(IUserServices userServices, GirifinDevContext context)
        {
            _userServices = userServices;
            _context = context;
        }
        [BindProperty]
        public AddOrEditUserDTO EditUser { get; set; }
        public void OnGet(int id)
        {
            EditUser = _context.Users.Where(u => u.Id == id).Select(s => new AddOrEditUserDTO
            {
                Description = s.Description,
                Email = s.Email,
                GitHub = s.GitHub,
                Id = s.Id,
                Password = s.Password,
                LinkDin = s.LinkDin,
                SiteLink = s.SiteLink,
                UserName = s.UserName,
                UserSkil = s.UserSkil,
            }).SingleOrDefault();
        }
        public IActionResult OnPost()
        {
            var user = _context.Users.Find(EditUser.Id);
            user.SiteLink = EditUser.SiteLink;
            user.LinkDin = EditUser.LinkDin;
            user.UserName = EditUser.UserName;
            user.UserSkil = EditUser.UserSkil;
            user.Description = EditUser.Description;
            user.Email = EditUser.Email.ToLower().Trim();
            user.GitHub = EditUser.GitHub;
            user.Password = EditUser.Password;
            _userServices.Save();
            if (EditUser.imgUp?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "AdminPanel", "UserPanel", user.Id + Path.GetExtension(EditUser.imgUp.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    EditUser.imgUp.CopyTo(stream);
                }
                user.ImageUrl = user.Id + Path.GetExtension(EditUser.imgUp.FileName);
                _userServices.Save();
            }
            return RedirectToPage("index");
        }
    }
}
