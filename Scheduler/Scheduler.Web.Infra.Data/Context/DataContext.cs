using Microsoft.EntityFrameworkCore;
using Scheduler.Web.Domain.Events.Entities;
using Scheduler.Web.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Infra.Data.Context
{

    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Event> Events { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
