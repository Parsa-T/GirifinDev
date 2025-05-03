using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GirifinDev.Pages.Admin.UserPanel
{
    public class IndexModel : PageModel
    {
        IUserServices _userServices;
        public IndexModel(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [BindProperty]
        public IEnumerable<_User> GetUserAll { get; set; }
        public void OnGet()
        {
            GetUserAll = _userServices.GetAllUser();
        }
    }
}
