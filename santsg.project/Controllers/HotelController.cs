using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using santsg.project.Data;
using santsg.project.Entities;
using santsg.project.Models.Request;
using Serilog;

namespace santsg.project.Controllers
{
    [Controller]
    public class HotelController : Controller
    {

        private readonly santsgProjectDbContext _dbContext;

        public HotelController(santsgProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult CreateHotelIndex()
        {
            return View();
        }
        public IActionResult UpdateHotelIndex()
        {
            return View();
        }
        public IActionResult DeleteHotelIndex()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ListHotel()
        {
            Log.Information("Hotels listed.");
            return Ok(await _dbContext.Hotels.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _dbContext.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            Log.Information($"HotelId: {id} to be viewed.");
            return Ok(hotel);
        }
        [HttpPost]
        public async Task<IActionResult> AddHotel(AddHotelRequest hotel)
        {
            Hotel newHotel = new()
            {
                Id = hotel.Id,
                HotelName = hotel.HotelName,
                City = hotel.City,
                Location = hotel.Location,
                StarRating = hotel.StarRating,
                HotelImage = hotel.HotelImage
            };

            await _dbContext.Hotels.AddAsync(newHotel);
            await _dbContext.SaveChangesAsync();
            Log.Information($"HotelName: {newHotel.HotelName}, HotelId: {newHotel.Id} added");
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel=await _dbContext.Hotels.FindAsync(id);
            if (hotel == null)
            {
                NotFound();
            }
            _dbContext.Hotels.Remove(hotel);
            await _dbContext.SaveChangesAsync();
            Log.Information($"Hotel Name: {hotel.HotelName} id:{hotel.Id} is deleted.");
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateHotelRequest hotel)
        {
            var updatedHotel = await _dbContext.Users.FindAsync(hotel?.Id);
            if (updatedHotel == null)
            {
                return NotFound();
            }


            updatedHotel.Username = hotel?.HotelName;
            updatedHotel.Password = hotel?.City;
            updatedHotel.Email = hotel?.Location;
            updatedHotel.PhoneNumber = hotel?.StarRating;
            updatedHotel.Age = hotel?.HotelImage;

            _dbContext.Update<User>(updatedHotel);
            await _dbContext.SaveChangesAsync();

            Log.Information($"{updatedHotel} user updated.");
            return RedirectToAction("Index", "Home");
        }
    }

}
