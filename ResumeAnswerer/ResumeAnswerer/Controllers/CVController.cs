using DBConnection.Models;
using Microsoft.AspNetCore.Mvc;
using ResumeAnswerer.Services.Commands;
using ResumeAnswerer.Services.Queries;

namespace ResumeAnswerer.Controllers
{
    [Route("api/[Controller]")]
    public class CVController : Controller
    {
        CompanyDBContext conn;
        IGetAllResumes getAll;
        IGetOneResume getOne;
        IChooseOneWorker chooseOneWorker;
        IsendMail mail;
        IDeleteAllArchive delete;

        MainClass main;

        public CVController(
            CompanyDBContext dbContext, 
            IGetAllResumes get, 
            IGetOneResume getOne, 
            IChooseOneWorker chooseOneWorker,
            IsendMail isend,
            IDeleteAllArchive delete)
        {
            this.conn = dbContext;
            this.getAll = get;
            this.getOne = getOne;
            this.chooseOneWorker = chooseOneWorker;
            this.mail = isend;
            this.delete = delete;

            this.main = new();
        }

        [HttpGet]
        [Route("/GetAllActive")]
        public async Task<List<ResumesModel>> GetAll()
            => 
            await getAll.GetAll(false);

        [HttpGet]
        [Route("/GetOneById")]
        public async Task<ResumesModel> GetOneById(long Id)
            => 
            await getOne.GetOneById(Id);


        [HttpPatch]
        [Route("/ChooseOneWorker")]
        public async Task<IActionResult> ChooseOneWorker(long Id)
        {
            var getOneWorker = await getOne.GetOneById(Id);
            if (getOneWorker.CandidatesResumesNo is 0)
                return BadRequest("Nie znaleziono podanego kandydata!");

            await chooseOneWorker.updateOtherWorker(Id);

            return Ok(mail.send(main.messageToOtherCandidates(getOneWorker.Role), await getAll.GetAll(true)));
        }


        [HttpDelete]
        [Route("/DeleteArchiveCandidates")]
        public async Task<IActionResult> DeleteArchiveCandidates(long Id)
            =>
            await delete.DeleteArchive() ? Ok("Usunięto!") : BadRequest("Nie ma już archiwum!");
        

    }
}