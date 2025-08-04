namespace ResumeAnswerer.Services.Commands
{
    public interface IDeleteAllArchive
    {
        Task<bool> DeleteArchive();
    }
}