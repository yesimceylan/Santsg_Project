using System.Net.Cache;

namespace santsg.project.Entities
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Age { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        

    }
}
