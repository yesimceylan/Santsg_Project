using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using santsg.project.Data;
using santsg.project.Entities;
using santsg.project.Interfaceses;
using santsg.project.Models;
using santsg.project.Services;
using Serilog;

namespace santsg.project.Controllers
{
    [Controller]
    public class UserController : ControllerBase
    {
        private readonly santsgProjectDbContext _dbContext;
        private readonly IMailService _mailService;

        public UserController(santsgProjectDbContext dbContext, IMailService mailService)
        {
            _dbContext = dbContext;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            Log.Information("Users listed."); 
            return Ok(await _dbContext.Users.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                Log.Information($"User with id {user?.Id} not found.");
                return NotFound(); 
            }
            Log.Information($"User with id {user?.Id} is listed."); 
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequestModel User)
        {
            User newUser = new()
            {
                Username = User.Username,
                Password = User.Password,
                Email = User.Email
            };
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();


            string toMail = newUser.Email;
            string subject = "Information!";
            string body = "Your registration has been successfully created.";

            await _mailService.SendEmailAsync(toMail, subject, body);
            Log.Information($"{newUser} user added."); 
            return Ok("Email sent successfully. ");

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteUser([FromBody] int id)
        {
            var deletedUser = await _dbContext.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (deletedUser == null) 
            {
                Log.Information("User not found during deletion!");
                return NotFound();
            }
            else
            {
                Log.Information($"{deletedUser} user silindi."); 
                return Ok($" {deletedUser} user deleted." );
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestModel user)
        {
            var updatedUser = await _dbContext.Users.FindAsync(user.Id);
            if (updatedUser == null)
            {
                return NotFound(); 
            }


            updatedUser.Username = user?.Username;
            updatedUser.Password = user?.Password;
            updatedUser.Email = user?.Email;

            await _dbContext.SaveChangesAsync();

            Log.Information($"{updatedUser} user updated.");
            return Ok(updatedUser);
        }
    }


}
