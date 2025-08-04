using DBConnection.Models;

namespace ResumeAnswerer.Services.Commands
{
    public interface IGetAllResumes
    {
        Task<List<ResumesModel>> GetAll(bool IsArchive);
    }
}