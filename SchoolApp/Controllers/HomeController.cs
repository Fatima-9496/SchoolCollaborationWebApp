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
            
                var mostRecentItem = _context.Announcements.Include(a => a.AppUser)
            .OrderByDescending(item => item.PostDate)
            .Take(3) // Retrieve the top 3 most recent announcements
            .ToList();
            if (mostRecentItem == null)
            {
                ViewBag.MostRecentItem = null;
            }
            ViewBag.MostRecentItem = mostRecentItem;



            var mostRecentProject = _context.Projects
            .OrderByDescending(item => item.DateCompleted)
            .Take(3) // Retrieve the top 3 most recent announcements
            .ToList();
            ViewBag.MostRecentProject = mostRecentProject;

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
                                                 s.AppUser.FirstName.Contains(searchString));
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