using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolApp.Data;
using SchoolApp.Models;
using System.Data;
using System.Diagnostics;

namespace SchoolApp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index(string? searchString)
        {

            //if (User.Identity.IsAuthenticated)
            //{
            //    if (User.IsInRole("Teacher"))
            //    {
            //        return RedirectToAction("Index", "Teacher"); // Redirect to Teacher controller's action
            //    }
            //    else if (User.IsInRole("Student"))
            //    {
            //        return RedirectToAction("Index", "Student"); // Redirect to Student controller's action
            //    }
            //}

            //// Query for announcements
            //var announcementQuery = _context.Announcements
            //    .OrderByDescending(item => item.PostDate)
            //    .AsQueryable();

            //// Query for projects
            //var projectQuery = _context.Projects
            //    .OrderByDescending(item => item.DateCompleted)
            //    .AsQueryable();

            //// Apply search filter if searchString is provided
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    searchString = searchString.ToLower();
            //    announcementQuery = announcementQuery
            //        .Where(item => item.AnnouncementTitle.ToLower().Contains(searchString) || 
            //        item.AnnouncementDescription.ToLower().Contains(searchString));

            //    projectQuery = projectQuery
            //        .Where(item => item.ProjectTitle.ToLower().Contains(searchString) || 
            //        item.ProjectDescription.ToLower().Contains(searchString));
            //}

            //// Retrieve the top 3 most recent announcements
            //var mostRecentAnnouncements = announcementQuery
            //    .Take(3)
            //    .ToList();

            //// Retrieve the top 3 most recent projects
            //var mostRecentProjects = projectQuery
            //    .Take(3)
            //    .ToList();

            //var announcementSql = announcementQuery.ToQueryString();
            //var projectSql = projectQuery.ToQueryString();

            //// Log the generated SQL queries
            //// Replace 'logger' with your actual logger implementation
            //_logger.LogInformation("Announcement SQL Query: {Sql}", announcementSql);
            //_logger.LogInformation("Project SQL Query: {Sql}", projectSql);


            //ViewBag.MostRecentAnnouncements = mostRecentAnnouncements;
            //ViewBag.MostRecentProjects = mostRecentProjects;

            //return View();

            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction("Index", "Teacher"); // Redirect to Teacher controller's action
                }
                else if (User.IsInRole("Student"))
                {
                    return RedirectToAction("Index", "Student"); // Redirect to Student controller's action
                }
            }
            var mostRecentItem = _context.Announcements
            .OrderByDescending(item => item.PostDate)
            .Take(3) // Retrieve the top 3 most recent announcements
            .ToList();
            ViewBag.MostRecentItem = mostRecentItem;

            var mostRecentProject = _context.Projects
            .OrderByDescending(item => item.DateCompleted)
            .Take(3) // Retrieve the top 3 most recent announcements
            .ToList();
            ViewBag.MostRecentProject = mostRecentProject;

            return View();

        }
        public IActionResult About()
        {           

            return View();

        }
        public IActionResult AnnouncementDetail(string? searchString)
        {
            var myannouncements = from s in _context.Announcements
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                myannouncements = myannouncements.Where(s => s.AnnouncementTitle!.Contains(searchString) ||
                                                 s.AnnouncementDescription.Contains(searchString) ||
                                                 s.AnnouncementAuthor.Contains(searchString));
            }
            return View(myannouncements.ToList());
        }

        public IActionResult ProjectDetail(string? searchString)
        {
            var myproject = from s in _context.Projects
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                myproject = myproject.Where(s => s.ProjectTitle!.Contains(searchString) ||
                                                 s.ProjectDescription.Contains(searchString) ||
                                                 s.ProjectArea.Contains(searchString));
            }
            return View(myproject.ToList());
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}