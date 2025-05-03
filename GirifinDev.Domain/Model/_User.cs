using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Domain.Model
{
    public class _User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSkil { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string LinkDin { get; set; }
        public string SiteLink { get; set; }
        public string GitHub { get; set; }
    }
}
