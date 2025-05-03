using GirifinDev.Application.DTO;
using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GirifinDev.Pages.Admin.UserPanel
{
    public class AddModel : PageModel
    {
        IUserServices _userServices;
        public AddModel(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [BindProperty]
        public AddOrEditUserDTO AddUsers { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _User user = new _User()
            {
                Description = AddUsers.Description,
                Email = AddUsers.Email.ToLower().Trim(),
                GitHub = AddUsers.GitHub,
                LinkDin = AddUsers.LinkDin,
                Password = AddUsers.Password,
                SiteLink = AddUsers.SiteLink,
                UserName = AddUsers.UserName,
                UserSkil = AddUsers.UserSkil,
                ImageUrl = AddUsers.UserName
            };
            _userServices.RegisterUser(user);
            _userServices.Save();
            if (AddUsers.imgUp?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "AdminPanel", "UserPanel", user.Id + Path.GetExtension(AddUsers.imgUp.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    AddUsers.imgUp.CopyTo(stream);
                }
                user.ImageUrl = user.Id + Path.GetExtension(AddUsers.imgUp.FileName);
                _userServices.Save();
            }
            return RedirectToPage("index");
        }
    }
}
