using DBConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace ResumeAnswerer.Services.Commands
{
    public class GetOneResume : IGetOneResume
    {
        CompanyDBContext conn;
        public GetOneResume(CompanyDBContext dbContext)
        {
            conn = dbContext;
        }
        public async Task<ResumesModel> GetOneById(long Id)
        {
            var getOne = await conn.Resumes.Where(item => item.Id == Id && !item.IsArchive).AsNoTracking()
                .Select(item => new ResumesModel()
                {
                    FullName = item.CandidatesResumesNoNavigation.FullName,
                    Role = item.CandidatesResumesNoNavigation.RoleNavigation.RoleName,
                    Address = item.CandidatesResumesNoNavigation.Address,
                    CandidatesResumesNo = item.CandidatesResumesNo,
                    Date = item.Date,
                    IsArchive = item.IsArchive

                }).AsNoTracking().FirstOrDefaultAsync();

            return getOne is null ? new ResumesModel() : getOne;
        }
    }
}
