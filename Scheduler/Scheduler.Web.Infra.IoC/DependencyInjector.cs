using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Web.Domain.Core.Bus;
using Scheduler.Web.Domain.Core.Notifications;
using Scheduler.Web.Domain.Core.Transactions;
using Scheduler.Web.Infra.Bus;
using Scheduler.Web.Infra.Data.Context;
using Scheduler.Web.Infra.Data.Transactions;

namespace Scheduler.Web.Infra.IoC
{

    public static class DependencyInjector
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Bus
            RegisterBus(services);

            // Domain notifications
            RegisterDomainNotification(services);

            // Data
            RegisterDataContext(services);

            // Modules
            RegisterModules(services);
        }

        private static void RegisterBus(IServiceCollection services)
        {
            services.AddScoped<IBus, InMemoryBus>();
        }

        private static void RegisterDomainNotification(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<Domain.Core.Notifications.DomainNotification>, DomainNotificationHandler>();
        }

        private static void RegisterDataContext(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DataContext>();
        }

        private static void RegisterModules(IServiceCollection services)
        {
            EventDependencyInjector.Register(services);
        }
    }
}
