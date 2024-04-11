using Microsoft.AspNetCore.Mvc;
using santsg.project.Data;
using santsg.project.Entities;
using santsg.project.Interfaceses;
using santsg.project.Models.Request;
using Serilog;

namespace santsg.project.Controllers
{
    public class CreateLoginController : Controller
    {
        private readonly santsgProjectDbContext _dbContext;
        private readonly IMailService _mailService;

        public CreateLoginController(santsgProjectDbContext dbContext, IMailService mailService)
        {
            _dbContext = dbContext;
            _mailService = mailService;
        }

        public IActionResult CreateUserLoginIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserLogin(CreateLoginRequest User)
        {
            User newUser = new()
            {
                Username = User.Username,
                Password = User.Password,
                Email = User.Email,
                PhoneNumber = User.PhoneNumber,
                Age = User.Age

            };
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();


            string? toMail = newUser.Email;
            string subject = "Information!";
            string body = "Your registration has been successfully created.";

            await _mailService.SendEmailAsync(toMail, subject, body);
            Log.Information($" Username : {newUser.Username} Email: {newUser.Email} user added.");
            return RedirectToAction("Index", "Login");

        }
    }
}
