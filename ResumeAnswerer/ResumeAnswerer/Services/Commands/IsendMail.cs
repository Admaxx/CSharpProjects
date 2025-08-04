using DBConnection.Models;

namespace ResumeAnswerer.Services.Commands
{
    public interface IsendMail
    {
        public string send(string defaultMessage, List<ResumesModel> recipients);
    }
}