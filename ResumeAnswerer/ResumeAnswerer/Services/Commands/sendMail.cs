using DBConnection.Models;
using System.Net.Mail;



namespace ResumeAnswerer.Services.Commands
{
    public class sendMail : IsendMail
    {
        public string send(string defaultMessage, List<ResumesModel> recipients)
        {
            foreach (var reciptient in recipients)
            {
                //Todo mail sender
            }
            return defaultMessage;
        }
    }
}
