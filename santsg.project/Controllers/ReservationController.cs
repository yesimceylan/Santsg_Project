using Microsoft.AspNetCore.Mvc;
using santsg.project.Data;
using santsg.project.Entities;
using santsg.project.Models.Request;
using Serilog;
using System.Security.Policy;

namespace santsg.project.Controllers
{
    public class ReservationController : Controller
    {
        private readonly santsgProjectDbContext _dbContext;
        public ReservationController(santsgProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult ReservationIndex()
        {
            return View();
        }
        public async Task<IActionResult> CreateReservation(CreateReservationRequest res)
        {
            Reservation newres = new()
            {
                rezName = res.rezName,
                rezPhoneNumber = res.rezPhoneNumber,
                rezEmail = res.rezEmail,
                rezPerson = res.rezPerson,
                rezDescription = res.rezDescription,
                rezDate = res.rezDate,
                rezEndDate = res.rezEndDate,
            };
            await _dbContext.Reservations.AddAsync(newres);
            await _dbContext.SaveChangesAsync();
            Log.Information($"{newres.Id} new reservation registration.");
            return Ok("Your reservation has been completed successfully.");
        }
    }
}
