using NuGet.Protocol.Plugins;

namespace santsg.project.Models.Request
{
    public class UpdateUserRequestModel 
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Age { get; set; }
        public DateTime CreateDate { get; set; }
        
    }
}
