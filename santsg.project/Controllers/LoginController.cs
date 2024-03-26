using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using santsg.project.Data;

namespace santsg.project.Controllers
{
    public class LoginController : Controller
    {
        private readonly santsgProjectDbContext _dbContext;
        public LoginController(santsgProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Index", "Login");
            }
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null || user.Password != password)
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Home");

        }
    } 
}

