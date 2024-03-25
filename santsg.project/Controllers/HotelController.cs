﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetHotelIndex()
        {
            var hotels = _dbContext.Hotels.ToList();
            Log.Information("Hotels listed.");
            return View(hotels);
        }
        public IActionResult GetHotelByIdIndex()
        {
            return View();
        }

        public IActionResult SearchHotelIndex()
        {
            return View();
        }
        public IActionResult SearchedHotelIndex()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetHotelById(Guid id)
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
        public async Task<IActionResult> DeleteHotel(Guid id)
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
        public async Task<IActionResult> UpdateHotel(UpdateHotelRequest hotel)
        {
            var updatedHotel = await _dbContext.Hotels.FindAsync(hotel?.Id);
            if (updatedHotel == null)
            {
                return NotFound();
            }


            updatedHotel.HotelName = hotel?.HotelName;
            updatedHotel.City = hotel?.City;
            updatedHotel.Location = hotel?.Location;
            updatedHotel.StarRating = hotel?.StarRating;
            updatedHotel.HotelImage = hotel?.HotelImage;

            _dbContext.Update<Hotel>(updatedHotel);
            await _dbContext.SaveChangesAsync();

            Log.Information($"{updatedHotel} user updated.");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> SearchHotel(string city)
        {
            var hotels = await _dbContext.Hotels.Where(x => x.City.Contains(city)).ToListAsync();
            if (hotels.Count == 0)
            {
                return NotFound("No results found for your search.");
            }
            else
            {
                ViewBag.Hotels = hotels;
                return View("SearchedHotelIndex");
            }
        }

    }

}
