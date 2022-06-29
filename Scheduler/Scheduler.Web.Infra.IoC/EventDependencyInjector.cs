using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Events.Commands;
using Scheduler.Web.Domain.Events.Commands.Handlers;
using Scheduler.Web.Domain.Events.Repositories;
using Scheduler.Web.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.infra.IoC
{

    public static class EventDependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            // Commands
            services.AddScoped<IRequestHandler<AddEventCommand, CommandResult>, EventCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteEventCommand, CommandResult>, EventCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateEventCommand, CommandResult>, EventCommandHandler>();

            // Repositories
            services.AddScoped<IEventRepository, EventRepository>();
        }
    }
}
