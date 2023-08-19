using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Data.Migrations;
using SchoolApp.Models;

namespace SchoolApp.Controllers
{
    public class StudentController : Controller
    {
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

    }
}
