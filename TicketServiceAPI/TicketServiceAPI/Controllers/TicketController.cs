using Exceptionless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketServiceAPI.Models;
using TicketServiceAPI.ScaffoldModels;

namespace TicketServiceAPI.Controllers
{
    [Route("api/[Controller]/")]
    public class TicketController : Controller
    {
        TicketsContext conn;
        public TicketController(TicketsContext ticketsContext)
        {
            conn = ticketsContext;
        }

        [HttpGet]
        [Route("GetAllTickets")]
        public IQueryable<Ticketsdetail> AllTickets()
        {
            return conn.Ticketsdetails.AsQueryable();
        }

        [HttpGet]
        [Route("GetLastTicket")]
        public async Task<Ticketsdetail> LastTicket()
        {
            if (await conn.Ticketsdetails.AnyAsync())
                return await conn.Ticketsdetails.OrderByDescending(item => item.Id).FirstAsync();
            return new Ticketsdetail();
        }

        [HttpGet]
        [Route("GetTicketById")]
        public async Task<List<Ticketsdetail>> TicketById(long Id)
        {
            if(await conn.Ticketsdetails.AnyAsync())
                return await conn.Ticketsdetails.Where(item => item.Id == Id).ToListAsync();
            return [];
        }

        [HttpPost]
        [Route("PostTicket")]
        public async Task<IActionResult> TicketDetail(NewTicket ticketModel) 
        {
            await conn.Ticketsdetails.AddAsync(new Ticketsdetail
            {
                Description = ticketModel.Description,
                Subject = ticketModel.Subject,
                CreateTime = DateTime.Now
            });
            
            return await conn.SaveChangesAsync() > 0 
                ? Created() : BadRequest(); 
        }
    }
}
