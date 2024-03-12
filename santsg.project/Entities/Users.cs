namespace santsg.project.Entities
{
    public class Users : BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
