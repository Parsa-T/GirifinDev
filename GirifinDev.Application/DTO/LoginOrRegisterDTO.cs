using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Application.DTO
{
    public class LoginUserDTO
    {
        public int Id { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = ("لطفا {0} را وارد کنید"))]
        [EmailAddress(ErrorMessage = "آدرس وارد شده صحیح نمی باشد")]
        public string Email { get; set; }
        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = ("لطفا {0} را وارد کنید"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "من را بخاطربسپار")]
        public bool RememberMe { get; set; }
    }
}
