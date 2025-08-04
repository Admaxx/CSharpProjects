using DBConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace ResumeAnswerer.Services.Commands
{
    public class DeleteAllArchive : IDeleteAllArchive
    {
        CompanyDBContext conn;
        public DeleteAllArchive(CompanyDBContext dbContext)
        {
            conn = dbContext;
        }

        public async Task<bool> DeleteArchive()
        {
            return await conn.Resumes.Where(item => !item.IsArchive).
                ExecuteDeleteAsync() > 0;
        }
    }
}
