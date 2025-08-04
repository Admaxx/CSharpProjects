using DBConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace ResumeAnswerer.Services.Commands
{
    public class GetAllResumes : IGetAllResumes
    {
        CompanyDBContext conn;
        public GetAllResumes(CompanyDBContext dbContext)
        {
            conn = dbContext;
        }
        public async Task<List<ResumesModel>> GetAll(bool isArchive)
        {
            return await conn.Resumes.Where(item => item.IsArchive == isArchive)
                .Select(item => new ResumesModel()
                {
                    CandidatesResumesNo = item.CandidatesResumesNo,
                    Date = item.Date,
                    FullName = item.CandidatesResumesNoNavigation.FullName,
                    Role = item.CandidatesResumesNoNavigation.RoleNavigation.RoleName,
                    Address = item.CandidatesResumesNoNavigation.Address,
                    IsArchive = item.IsArchive

                })
                .AsNoTracking()
                .AsQueryable()
                .ToListAsync();
        }
    }
}
