using DBConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace ResumeAnswerer.Services.Queries
{
    public class ChooseOneWorker : IChooseOneWorker
    {
        CompanyDBContext conn;
        public ChooseOneWorker(CompanyDBContext dbContext)
        {
            conn = dbContext;
        }

        public async Task<bool> updateOtherWorker(long Id)
        {
            return await
                conn.Resumes
                .Where(item => item.Id != Id)
                .ExecuteUpdateAsync(item => item.SetProperty(item => item.IsArchive, true)) > 0;
        }
    }
}
