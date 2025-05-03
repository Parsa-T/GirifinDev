using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Application.DTO
{
    public class AddOrEditProjectDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile imgUp { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
