using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Web.Application.Interfaces;
using Scheduler.Web.Application.Services;
using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Events.Commands;
using Scheduler.Web.Domain.Events.Commands.Handlers;
using Scheduler.Web.Domain.Events.Repositories;
using Scheduler.Web.Infra.Data.Repositories;

namespace Scheduler.Web.Infra.IoC
{

    public static class EventDependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            // Commands
            services.AddScoped<IRequestHandler<AddEventCommand, CommandResult>, EventCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteEventCommand, CommandResult>, EventCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateEventCommand, CommandResult>, EventCommandHandler>();

            // Services
            services.AddScoped<IEventAppService, EventAppService>();

            // Repositories
            services.AddScoped<IEventRepository, EventRepository>();
        }
    }
}
