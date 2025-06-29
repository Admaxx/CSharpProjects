using TicketService.Models;

namespace TicketService.Services.Read
{
    public class ShowTickets : IShowTickets
    {
        TicketsContext conn;
        public ShowTickets(TicketsContext _ticketsContext)
        {
            conn = _ticketsContext;
        }
        public IQueryable<Ticketsdetail> getTickets()
        {
            return conn.Ticketsdetails.ToList().AsQueryable();
        }
    }
}
