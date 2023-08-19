using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;
using System.Collections.Generic;

namespace SchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
