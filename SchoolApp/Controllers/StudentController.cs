using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
        //public bool UserExist = false;

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public async Task<IActionResult> ListOfCourses()
        {
            return _context.Courses != null ?
                          View(await _context.Courses.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Course'  is null.");
        }
        public IActionResult EnrollInACourse()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnrollInACourse(Enrollment enrollment, int id)
        {
            //string CaptureUserName = euserName;
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            //string? rowId = _context.AppUsers
            //.Where(e => e.UserName == CaptureUserName)
            //.Select(e => e.Id) 
            //.FirstOrDefault();
            //var columnValues = _context.AppUsers.Select(e => e.UserName).ToList();

            //var courseItem = await _context.Courses.FindAsync(id);
            var enroll = new Enrollment
            {
                CourseId = id,
                StudentId = userId
            };
            if (!ModelState.IsValid )
            {

                return View(enrollment);
            }
            _context.Add(enroll);
            await _context.SaveChangesAsync();
            //_context.Add(enrollment);
            //await _context.SaveChangesAsync();

            return RedirectToAction("Index");
                        
        }
        public async Task<IActionResult> ListOfAssignmentsAsync()
        {
            return _context.Assignments != null ?
                         View(await _context.Assignments.ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.Assignment'  is null.");
        }
        public IActionResult SubmitAssignment()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitAssignment(int id,AssignmentSubmission assignmentSubmission, int id)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignmentSubmission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignmentSubmission);
        }
    }

    }
}
