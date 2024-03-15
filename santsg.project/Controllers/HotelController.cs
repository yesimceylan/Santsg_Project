using Microsoft.AspNetCore.Mvc;
using santsg.project.Entities;


namespace santsg.project.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            var hotelList = new List<Hotel>() 
            { 
                new Hotel() 
                {
                    HotelName = "Star",
                    HotelLocation = "Konyaaltı"
                },
                new Hotel() 
                {
                    HotelName = "Cale",
                    HotelLocation = "Muratpasa"
                }
            };

            ViewBag.Hotel=hotelList;
            return View();
        }
    }
}
