using Autofac;
using TicketServiceAPI.Models;
using TicketServiceAPI.ScaffoldModels;

namespace TicketServiceAPI.Services
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TicketsContext>().AsSelf();
        }
    }
}
