namespace ResumeAnswerer.Services.Queries
{
    public interface IChooseOneWorker
    {
        Task<bool> updateOtherWorker(long Id); 
    }
}