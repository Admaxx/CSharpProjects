using TicketService.Models;

namespace TicketService.Components.Pages
{
    public partial class Home
    {
        private bool _loading;
        TicketsContext conn;
        public Home(TicketsContext TicketConn)
        {
            conn = TicketConn;
        }
        public IEnumerable<Ticketsdetail> ticketDetails;

        public IQueryable<Ticketsdetail> getTickets()
        {
            return conn.Ticketsdetails.ToList().AsQueryable();
        }
        protected override void OnInitialized()
        {
            ticketDetails = getTickets();
        }
    }
}