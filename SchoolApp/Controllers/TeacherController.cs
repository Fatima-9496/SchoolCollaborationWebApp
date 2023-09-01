using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace SchoolApp.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TeacherController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> AnnouncementIndex()
        {
            List<Announcement> announcements = await _context.Announcements.ToListAsync();
            return View(announcements);            
        }
        public IActionResult CreateAnnouncement()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnnouncement(Announcement announcement)
        {            
            if (!ModelState.IsValid)
            {
                return View(announcement);
            }            
            _context.Add(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction("AnnouncementIndex");
        }
        public async Task<IActionResult> AnnouncementEdit(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View(announcement);
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnnouncementEdit(int id, Announcement annocuncement)
        {
            if (id != annocuncement.AnnouncementId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(annocuncement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(annocuncement.AnnouncementId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AnnouncementIndex));
            }
            return View(annocuncement);
        }
        public async Task<IActionResult> AnnouncementDelete(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }
            var announcement = await _context.Announcements
                .FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View(announcement);
        }
        [HttpPost, ActionName("AnnouncementDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnnouncementDeleteConfirmed(int id)
        {
            if (_context.Announcements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Announcement' is null.");
            }
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AnnouncementIndex));
        }
        public async Task<IActionResult> CourseIndex(string searchString)
        {
            //List<Course> courses = await _context.Courses.ToListAsync();
            var courses = from m in _context.Courses
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.CourseName!.Contains(searchString));
            }

            return View(await courses.ToListAsync());
        }
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }            
            _context.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("CourseIndex");
        }
        public async Task<IActionResult> CourseEdit(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CourseEdit(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(course.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(CourseIndex));
            }
            return View(course);
        }
        public async Task<IActionResult> CourseDelete(int? id)
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

        [HttpPost, ActionName("CourseDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CourseDeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Course' is null.");
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CourseIndex));
        }
        public async Task<IActionResult> AssignmentIndex()
        {
            var assignmentsWithCourses = await _context.Assignments
            .Include(a => a.Course)
            .Select(a => new
            {
                a.AssignmentId,
                a.AssignmentTitle,
                a.AssignmentDescription,
                a.Deadline,
                CourseName = a.Course.CourseName
            })
            .ToListAsync();

            return View(assignmentsWithCourses);                   
        }
        public IActionResult CreateAssignment()
        {
            //var courseNames = _context.Courses.Select(course => course.CourseName).ToList();
            //ViewBag.CourseNames = courseNames;

            //var courses = _context.Courses.ToList();
            //var assignments = _context.Assignments.Include(a => a.Course).ToList();

            //ViewBag.Courses = new SelectList(courses, "CourseId", "CourseName");
            //ViewBag.Assignments = assignments;
            //ViewData["CourseNames"] = SelectList(_context.Courses, "CourseId", "CourseName");

            List<Course> courses = _context.Courses.ToList();
            courses.Insert(0, new Course { CourseId = 0, CourseName = "--Select Country Name--" });
            ViewBag.message = new SelectList(courses, "CourseId", "CourseName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return View(assignment);
            }
            //var course =  _context.Courses.ToList();
            //assignment.ListofCourses = course;
            _context.Add(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction("AssignmentIndex");
        }
        public async Task<IActionResult> AssignmentEdit(int? id)
        {
            var assignment = await _context.Assignments
            .Include(a => a.Course)
            .FirstOrDefaultAsync(a => a.AssignmentId == id);

            if (assignment == null)
            {
                return NotFound();
            }

            var courseNames = await _context.Courses
                .Select(c => new SelectListItem
                {
                    Value = c.CourseId.ToString(),
                    Text = c.CourseName
                })
                .ToListAsync();

            ViewBag.CourseNames = courseNames;

            return View(assignment);                       
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignmentEdit(int id, Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.AssignmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AssignmentIndex));
            }

            ViewBag.CourseNames = _context.Courses
                .Select(c => new SelectListItem
                {
                    Value = c.CourseId.ToString(),
                    Text = c.CourseName
                })
                .ToList();

            return View(assignment);                      
        }
        public IActionResult AssignmentDelete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var assignment = _context.Assignments
            .Include(a => a.Course)
            .FirstOrDefault(a => a.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }
        [HttpPost, ActionName("AssignmentDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignmentDeleteConfirmed(int id)
        {

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
            }
            else
            {
                return Problem("Entity set is null.");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AssignmentIndex));
        }
        public async Task<IActionResult> ListOfEnrollements()
        {
            var enrollmentsWithDetails = await _context.Enrollments
            .Include(e => e.Course)
            .Include(e => e.AppUser)
            .ToListAsync();

            return View(enrollmentsWithDetails);
        }
        public async Task<IActionResult> ListOfAssignSubmissions(int? id)
        {
            var submissions = await _context.AssignmentSubmissions
            .Where(submission => submission.AssignmentId == id)
            .Include(submission => submission.AppUser)
            .Include(submission => submission.Assignment)
        .ToListAsync();

            return View(submissions);
        }
        private bool AnnouncementExists(int id)
        {
            return (_context.Announcements?.Any(e => e.AnnouncementId == id)).GetValueOrDefault();
        }
        private bool CourseExists(int id)
        {
            return (_context.Courses?.Any(e => e.CourseId == id)).GetValueOrDefault();
        }
        private bool AssignmentExists(int id)
        {
            return (_context.Assignments?.Any(e => e.AssignmentId == id)).GetValueOrDefault();
        }
    }
}
