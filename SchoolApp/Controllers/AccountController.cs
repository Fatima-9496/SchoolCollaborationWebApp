using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
