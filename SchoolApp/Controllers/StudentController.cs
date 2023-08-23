using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Data.Migrations;
using SchoolApp.Models;
using System.Security.Claims;


namespace SchoolApp.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        public bool UserExist = false;

        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            if (project.ImageMediaUrl != null && project.ImageMediaUrl.Length > 0)
            {
                // Save the image file to the server and set the ImageUrl property
            
                project.ImageMediaUrl = "path_to_uploaded_image";
            }

            if (project.VideoMediaUrl != null && project.VideoMediaUrl.Length > 0)
            {
                // Save the video file to the server and set the VideoUrl property
                project.VideoMediaUrl = "path_to_uploaded_video";
            }
            _context.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult EnrollInACourse()
        {
            var courseNames = _context.Courses.Select(course => course.CourseName).ToList();
            ViewBag.CourseNames = courseNames;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnrollInACourse(Enrollment enrollment, string euserName)
        {
            string CaptureUserName = euserName;
            //string userId = User.Identity.GetUserId();
                /*User.FindFirstValue(ClaimTypes.NameIdentifier);*/
            string? rowId = _context.AppUsers
            .Where(e => e.UserName == CaptureUserName)
            .Select(e => e.Id) 
            .FirstOrDefault();
            var columnValues = _context.AppUsers.Select(e => e.UserName).ToList();
            string? check = rowId;
            foreach (var value in columnValues)
            {
                if (value == CaptureUserName)
                {
                    UserExist = true;
                }
                
            }


            if (!ModelState.IsValid && UserExist)
            {
                
                return View(enrollment);
            }
            
            _context.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
