namespace santsg.project.Models
{
    public class AddUserRequestModel 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }= DateTime.Now; 
        
    }
}
