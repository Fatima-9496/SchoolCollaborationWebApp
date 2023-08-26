using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;
using System;
using System.Collections.Generic;

namespace SchoolApp.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<AppUser> userManager;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;//I'll be back. eskeza sele erroru search argi eshi
            //this.userManager = userManager;
        }
        public IActionResult Index()
        {
            List<Announcement> announcements = _context.Announcements.ToList();
            return View(announcements);
           
        }

        public IActionResult CreateAnnouncement()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnnouncement([Bind("AnnouncementTitle,AnnouncementDescription,StartDate,EndDate")] Announcement announcement)
        {
            if(!ModelState.IsValid)
            {
                return View(announcement);
            }
            
            _context.Add(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
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
        public async Task<IActionResult> AnnouncementEdit(int id, [Bind("AnnouncementId,AnnouncementTitle,AnnouncementDescription,StartDate,EndDate")] Announcement annocuncement)
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
                return RedirectToAction(nameof(Index));
            }
            return View(annocuncement);
        }
        public async Task<IActionResult> ADelete(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var movie = await _context.Announcements
                .FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ADeleteConfirmed(int id)
        {
            if (_context.Announcements == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            var movie = await _context.Announcements.SingleOrDefaultAsync(i => i.AnnouncementId == id);
            if (movie != null)
            {
                _context.Announcements.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{

        //    var uTask = await _context.Announcements.FindAsync(id);
        //    if (uTask != null)
        //    {
        //        _context.Announcements.Remove(uTask);
        //    }
        //    else
        //    {
        //        return Problem("Entity set   is null.");
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> AnnouncementDelete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var user = await userManager.GetUserAsync(User);

        //    var uTask = _context.Announcements
        //        .FirstOrDefault(m => m.AnnouncementId == id);
        //    if (uTask == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(uTask);
        //}

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
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> CourseEdit(int? id)
        //{
        //    if (id == null || _context.Courses == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = await _context.Courses.FindAsync(id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(course);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CourseEdit(int id, Course course)
        //{
        //    if (id != course.CourseId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(course);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CourseExists(course.CourseId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(course);
        //}
        //public IActionResult CourseDelete(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = _context.Courses
        //        .FirstOrDefault(m => m.CourseId == id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(course);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CourseDeleteConfirmed(int id)
        //{

        //    var course = await _context.Courses.FindAsync(id);
        //    if (course != null)
        //    {
        //        _context.Courses.Remove(course);
        //    }
        //    else
        //    {
        //        return Problem("Entity set is null.");
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult CreateAssignment()
        {
            var courseNames = _context.Courses.Select(course => course.CourseName).ToList();
            ViewBag.CourseNames = courseNames;
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
            _context.Add(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> AssignmentEdit(int? id)
        //{
        //    if (id == null || _context.Assignments == null)
        //    {
        //        return NotFound();
        //    }

        //    var assignment = await _context.Assignments.FindAsync(id);
        //    if (assignment == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(assignment);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AssignmentEdit(int id, Assignment assignment)
        //{
        //    if (id != assignment.AssignmentId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(assignment);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AssignmentExists(assignment.AssignmentId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(assignment);
        //}
        //public IActionResult AssignmentDelete(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var assignment = _context.Assignments
        //        .FirstOrDefault(m => m.AssignmentId == id);
        //    if (assignment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(assignment);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AssignmentDeleteConfirmed(int id)
        //{

        //    var assignment = await _context.Assignments.FindAsync(id);
        //    if (assignment != null)
        //    {
        //        _context.Assignments.Remove(assignment);
        //    }
        //    else
        //    {
        //        return Problem("Entity set is null.");
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
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
