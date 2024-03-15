namespace santsg.project.Interfaceses
{
    public interface IMailService
    {
        Task SendEmailAsync(string toMail, string subject, string body);
    }
}
