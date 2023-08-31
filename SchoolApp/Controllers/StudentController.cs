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
        public async Task<IActionResult> ProjectIndex()
        {
            List<Project> projects = await _context.Projects.ToListAsync();

            return View(projects);
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
            
            _context.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProjectIndex");
        }
        public async Task<IActionResult> ProjectEdit(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectEdit(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExit(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ProjectIndex));
            }
            return View(project);
        }
        public async Task<IActionResult> ProjectDelete(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }
            var project = await _context.Projects
                .FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        [HttpPost, ActionName("ProjectDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectDeleteConfirmation(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Project' is null.");
            }
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ProjectIndex));
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
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            
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
            return RedirectToAction("Index");
                        
        }
        public IActionResult EnrollmentDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = _context.Enrollments
            .Include(a => a.Course)
            .FirstOrDefault(a => a.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }
        [HttpPost, ActionName("EnrollmentDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnrollmentDeleteConfirmed(int id)
        {

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
            }
            else
            {
                return Problem("Entity set is null.");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ListOfAssignmentsAsync()
        {
            var ListofAss = await _context.Assignments.ToListAsync(); 
            //_context.Assignments != null ?
            //             View() :
            //             Problem("Entity set 'ApplicationDbContext.Assignment'  is null.")
            return View(ListofAss);
        }
        public IActionResult SubmitAssignment(int id)
        {
            var assignment = _context.Assignments
            .Find(id);
            //ViewBag.IsSubmitted = false;
            return View(assignment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitAssignment(int? id,AssignmentSubmission assignmentSubmission, string? submissionText, string? submissionFile)
        {            
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            //AssignmentSubmission assignmentSubmission = _context.AssignmentSubmissions
            //.Include(a => a.Assignment) // Eager load the associated assignment
            //.FirstOrDefault(a => a.AssignmentId == assignmentId);

            

            var submit = new AssignmentSubmission
            {
                AssignmentId = id,
                StudentId = userId,
                SubmissionText = submissionText,
                SubmissionFileUrl = submissionFile,
                IsSubmitted = true,
                SubmissionDate = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                ViewBag.IsSubmitted = false;
                _context.Add(submit);
                await _context.SaveChangesAsync();
               
               
                return RedirectToAction(nameof(Index));
            }
            var assignment = _context.AssignmentSubmissions
                .Include(a => a.Assignment)
                .FirstOrDefault(a => a.AssignmentId == id);

            if (assignment == null)
            {
                return NotFound();
            }

            if (DateTime.Now > assignment.Assignment.Deadline)
            {
                ViewBag.SubmissionMessage = "Submission closed. Deadline has been reached.";
                return View("SubmissionClosed");
            }
            ViewBag.ISubmitted = true;
            return View(assignmentSubmission);
        }
        private bool ProjectExit(int id)
        {
            return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
    
}
