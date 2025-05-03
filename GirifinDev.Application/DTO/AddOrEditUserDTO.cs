using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Application.DTO
{
    public class AddOrEditUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSkil { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile imgUp { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string LinkDin { get; set; }
        public string SiteLink { get; set; }
        public string GitHub { get; set; }
        public bool IsAdmin { get; set; }
    }
}
