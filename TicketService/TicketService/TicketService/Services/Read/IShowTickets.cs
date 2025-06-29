using TicketService.Models;

namespace TicketService.Services.Read
{
    public interface IShowTickets
    {
        IQueryable<Ticketsdetail> getTickets();
    }
}
