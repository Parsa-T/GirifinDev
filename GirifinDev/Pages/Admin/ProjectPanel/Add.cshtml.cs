using GirifinDev.Application.DTO;
using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using GirifinDev.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GirifinDev.Pages.Admin.ProjectPanel
{
    public class AddModel : PageModel
    {
        Services.IProjectQueriServices _projectRepositoryDTO;
        Application.Interface.IProjectServices _projectServices;
        public AddModel(Services.IProjectQueriServices projectRepositoryDTO, Application.Interface.IProjectServices projectServices)
        {
            _projectServices = projectServices;
            _projectRepositoryDTO = projectRepositoryDTO;
        }
        [BindProperty]
        public ShowProjectDTO AddProject { get; set; }
        public void OnGet()
        {
            AddProject = _projectRepositoryDTO.ShowProject();
        }
        public IActionResult OnPost()
        {
            var pro = new _Project()
            {
                CategoryId = AddProject.CategoryId,
                Name = AddProject.Name,
                Description = AddProject.Description,
                Link = AddProject.Link,
                ImageUrl = AddProject.Name
            };
            _projectServices.RegisterProject(pro);
            _projectServices.Save();
            if (AddProject.imgUp?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot","AdminPanel","ProjectPanel",
                    pro.Id + Path.GetExtension(AddProject.imgUp.FileName));
                using (var stream =new FileStream(filePath,FileMode.Create))
                {
                    AddProject.imgUp.CopyTo(stream);
                }
                pro.ImageUrl = pro.Id + Path.GetExtension(AddProject.imgUp.FileName);
                _projectServices.Save();
            }
            return RedirectToPage("index");
        }
    }
}
