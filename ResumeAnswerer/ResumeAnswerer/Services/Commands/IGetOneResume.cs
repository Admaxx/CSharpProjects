using DBConnection.Models;

namespace ResumeAnswerer.Services.Commands
{
    public interface IGetOneResume
    {
        Task<ResumesModel> GetOneById(long Id);
    }
}