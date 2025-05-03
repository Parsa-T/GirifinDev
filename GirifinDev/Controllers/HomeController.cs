using GirifinDev.Application.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Models;
using GirifinDev.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GirifinDev.Controllers
{
    public class HomeController : Controller
    {
        IProjectQueriServices _project;
        IProjectServices _projectService;
        IUserTeamRepository _teamUser;
        IPageCommentServices _pageComment;
        public HomeController(IProjectQueriServices project, IUserTeamRepository user, IPageCommentServices pageComment, IProjectServices projectServices)
        {
            _project = project;
            _teamUser = user;
            _pageComment = pageComment;
            _projectService = projectServices;
        }

        public IActionResult Index()
        {
            var pro = _project.ShowAllProject();
            var us = _teamUser.GetAllUserTeam();
            var cg = _project.GetAllCategory();
            var commentcount = _pageComment.CountComment();
            var ProjectCount = _projectService.CountProject();
            ViewBag.AllProject = pro;
            ViewBag.TeamUser = us;
            ViewBag.Category = cg;
            ViewBag.Commentcount = commentcount;
            ViewBag.ProjectCount = ProjectCount;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string name, string email, string comment)
        {
            if (name != null && email != null && comment != null)
            {
                _PageComment c = new _PageComment()
                {
                    comment = comment,
                    CreateTime = DateTime.Now,
                    Email = email.ToLower().Trim(),
                    Name = name,
                };
                _pageComment.AddComment(c);
                return Redirect("/");
            }
            return Redirect("/");
        }
        [HttpGet]
        public IActionResult GetProjectsByCategory(int categoryId)
        {
            if (categoryId > 0)
            {
                var projects = _project.GetprojectByCategoryId(categoryId);
                return Json(projects);
            }
            else
            {
                var AllProject = _project.ShowAllProject();
                return Json(AllProject);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
