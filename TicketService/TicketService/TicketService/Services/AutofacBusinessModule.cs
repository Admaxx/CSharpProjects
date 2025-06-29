using Autofac;
using TicketService.Models;
using TicketService.Services.Read;

internal class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ShowTickets>().As<IShowTickets>();
        builder.RegisterType<TicketsContext>().AsSelf();
    }
}