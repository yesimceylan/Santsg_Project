namespace santsg.project.Models.Request
{
    public class UpdateHotelRequest
    {
        public int Id { get; set; }
        public string? HotelName { get; set; }
        public string? City { get; set; }
        public string? Location { get; set; }
        public string? StarRating { get; set; }
        public string? HotelImage { get; set; }

    }
}
