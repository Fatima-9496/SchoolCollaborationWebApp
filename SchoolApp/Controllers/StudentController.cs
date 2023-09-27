using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SchoolApp.Data;
using SchoolApp.Data.Migrations;
using SchoolApp.Models;
using System;
using System.Security.Claims;



namespace SchoolApp.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
       
        private readonly IWebHostEnvironment _hostEnvironment;

        public StudentController(ApplicationDbContext context, UserManager<IdentityUser> userManager,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> ListOfNotes()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var nots = _context.MNotes.Where(a => a.StudentId == userId).ToList();
            return View(nots);
        }
        public IActionResult MyNote()
        {            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MyNote(MNote note)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            if(ModelState.IsValid)
            {
                note.CreatedDate = DateTime.Now;
                note.StudentId = userId;
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListOfNotes));
            }
            return View(note);
        }
        public async Task<IActionResult> NoteEdit(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }
            var note = await _context.MNotes.FindAsync(id);
            if (note.StudentId != userId)
            {
                return NotFound();
            }
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NoteEdit(int id, MNote note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.MNotes.FirstOrDefault(x => x.Id == id);
                    if (data != null)
                    {
                        data.Title = note.Title;
                        data.Content = note.Content;
                        data.CreatedDate = DateTime.Now;
                        
                        //data.AnnouncementPhoto = result != null ? result.Url?.ToString() : null;
                        
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExit(note.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListOfNotes));
            }
            return View(note);
        }
        public IActionResult Index()
        {
            var mostRecentItem = _context.Announcements.Include(a => a.AppUser)
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
        public async Task<IActionResult> ProjectIndex(string? searchString)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var myproject = from s in _context.Projects
                                 select s;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                myproject = myproject.Where(s => s.ProjectTitle!.Contains(searchString) ||
                                                 s.ProjectDescription!.Contains(searchString) ||
                                                 s.ProjectArea!.Contains(searchString));
            }
            return View(myproject.Where(project => project.StudentId == userId)
            .ToList());
        }
        
        public IActionResult CreateProject()
        {            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(Project project)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            if (ModelState.IsValid)
            {
                if (project.ImageFile != null)
                {
                    string uploadedto = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    string uniqueName = Guid.NewGuid() + "-" + project.ImageFile.FileName;
                    string filepath = Path.Combine(uploadedto, uniqueName);
                    await project.ImageFile.CopyToAsync(new FileStream(filepath, FileMode.Create));
                    project.ImageUrl = "Images/" + uniqueName;
                }

                if (project.PhotoFile != null)
                {
                    string uploadedto = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    string uniqueName = Guid.NewGuid() + "-" + project.PhotoFile.FileName;
                    string filepath = Path.Combine(uploadedto, uniqueName);
                    await project.PhotoFile.CopyToAsync(new FileStream(filepath, FileMode.Create));
                    project.MediaUrl = "Images/" + uniqueName;
                }
                DateTime currentDateTime = DateTime.Now;
                if (project.DateCompleted < currentDateTime)
                {
                    ModelState.AddModelError("SelectedDateTime", "Please select a date-time in the future.");
                    return View(project);
                }
                project.StudentId = userId;
                _context.Add(project);
                await _context.SaveChangesAsync();

                return RedirectToAction("ProjectIndex");
            }
            return View(project);
        }
        public async Task<IActionResult> ProjectEdit(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }
            var project = await _context.Projects.FindAsync(id);
            if(project.StudentId != userId)
            {
                return NotFound();
            }
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
                try { 
                    var data = _context.Projects.FirstOrDefault(x => x.ProjectId == id);                
                    if (data != null)
                    {
                        data.ProjectTitle = project.ProjectTitle;
                        data.ProjectDescription = project.ProjectDescription;
                        DateTime currentDateTime = DateTime.Now;
                        if (project.DateCompleted < currentDateTime)
                        {
                            ModelState.AddModelError("SelectedDateTime", "Please select a date-time in the future.");                           
                            return View(project);
                        }
                        //data.AnnouncementPhoto = result != null ? result.Url?.ToString() : null;
                        if (project.PhotoFile != null)
                        {
                            string uploadedto = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                            string uniqueName = Guid.NewGuid() + "-" + project.PhotoFile.FileName;
                            string filepath = Path.Combine(uploadedto, uniqueName);
                            await project.PhotoFile.CopyToAsync(new FileStream(filepath, FileMode.Create));
                            data.MediaUrl = project.MediaUrl = "Images/" + uniqueName;
                        }
                        await _context.SaveChangesAsync();
                    }                                             
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
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }
            var project = await _context.Projects
                .FindAsync(id);
            if (project.StudentId != userId)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> ListOfCourses(string? searchString)
        {           
            var courses = from s in _context.Courses
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.CourseName!.Contains(searchString) ||
                                             s.CourseDescription!.Contains(searchString));
            }
            return View(await courses.ToListAsync());
        }
        public async Task<IActionResult> ListOfEnrollments(string? searchString)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var enrolled = from s in _context.Enrollments
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                enrolled = enrolled.Where(s => s.Course.CourseName!.Contains(searchString) ||
                                             s.AppUser.UserName!.Contains(searchString));
                                   
            }

           // var myEnrollmetn = _context.Enrollments
           // .Where(enrollment => enrollment.StudentId == userId).Include(a => a.Course)
           /// .ToList();
            return View(enrolled.Where(project => project.StudentId == userId).Include(a => a.Course)
            .ToList());
        }
        public async Task<IActionResult> EnrollInACourse(int? id)
        {            
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses
                .FindAsync(id);
            
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
            
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
        public async Task<IActionResult> EnrollmentDelete(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            if (id == null)
            {
                return NotFound();
            }

            var enrollment = _context.Enrollments
            .Include(a => a.Course)
            .FirstOrDefault(a => a.EnrollmentId == id);
            if (enrollment.StudentId != userId)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> ListOfAssignments(string? searchString)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            
            var enrolledCourses = _context.Enrollments
                .Where(e => e.StudentId == userId)
                .SelectMany(e => e.Course.Assignments).Include(course => course.Course)
                .ToList();
            //var course = _context.Courses.ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                enrolledCourses = enrolledCourses
                    .Where(a => a.AssignmentTitle.Contains(searchString) ||
                                a.AssignmentDescription.Contains(searchString) ||
                                a.Course.CourseName.Contains(searchString))
                    .ToList();
            }

            return View(enrolledCourses);
        }
        public async Task<IActionResult> SubmitAssignment(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            bool flag = false;
            if (id == null)
            {
                return NotFound();
            }
            var assignment = _context.Assignments
            .Find(id);
            var courseData = _context.Enrollments.Where(a => a.StudentId == userId).ToListAsync();
            foreach(var courser in await courseData) 
            {
                if(assignment.CourseId == courser.CourseId) 
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                return NotFound();
            }
            //if (assignment.Course.Enrollments.StudentId != userId)
            //{
            //    return NotFound();
            //}
            //ViewBag.IsSubmitted = false;
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitAssignment(int? id,AssignmentSubmission assignmentSubmission, string? submissionText, IFormFile? AnnouncementFile)
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
                //SubmissionFileUrl = submissionFile,                
                SubmissionDate = DateTime.Now
            };
            if (AnnouncementFile != null)
            {
                string uploadedto = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                string uniqueName = Guid.NewGuid() + "-" + AnnouncementFile.FileName;
                string filepath = Path.Combine(uploadedto, uniqueName);
                await AnnouncementFile.CopyToAsync(new FileStream(filepath, FileMode.Create));
                submit.AnnouncementDocFile = "Images/" + uniqueName;
            }

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
            
            return View(assignmentSubmission);
        }
        private bool ProjectExit(int id)
        {
            return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
    
}
