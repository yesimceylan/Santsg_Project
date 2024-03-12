using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using santsg.project.Data;
using santsg.project.Entities;
using santsg.project.Models;

namespace santsg.project.Controllers
{

    public class UserController : ControllerBase {
        private readonly santsgProjectDbContext _dbContext;

        public UserController(santsgProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _dbContext.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequestModel User)
        {
            Users newUser = new()
            {
                Username = User.Username,
                Password = User.Password,
                Email = User.Email
            };
            await _dbContext.Users.AddAsync(newUser); 
            await _dbContext.SaveChangesAsync();

            return Ok(newUser);
            
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deletedUser = await _dbContext.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (deletedUser == null)
                return NotFound();
            else
                return Ok("Kişi silindi !");   
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequestModel user)
        {
            var updatedUser = await _dbContext.Users.FindAsync(user.Id);
            Users newUser = new(); 
            
            newUser.Username = updatedUser?.Username;
            newUser.Password = updatedUser?.Password;
            newUser.Email = updatedUser?.Email;

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return Ok(newUser);
        }
    }
     
    
}
