using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System.Collections.Generic;
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

            return conn.Ticketsdetails
                .AsNoTracking()
                .Select(item => new Ticketsdetail()
                {   
                    CreateTime = item.CreateTime,
                    Stage = item.Stage,
                    Subject = item.Subject,
                    Description = item.Description,
                    SupportPerson = item.SupportPerson,
                    ModifyTime = item.ModifyTime 
                })
                .ToList()
                .AsQueryable();
        }
        protected override void OnInitialized()
        {
            ticketDetails = getTickets();
        }
    }
}