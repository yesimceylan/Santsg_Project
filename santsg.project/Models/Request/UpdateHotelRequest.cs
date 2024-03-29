
namespace santsg.project.Models.Request
{
    public class UpdateHotelRequest
    {
        public Guid Id { get; set; }
        public string? HotelName { get; set; }
        public string? City { get; set; }
        public string? Location { get; set; }
        public string? StarRating { get; set; }
        public string? HotelImage { get; set; }
        public string? HotelImage2 { get; set; }
        public string? HotelImage3 { get; set; }

    }
}
