using Microsoft.EntityFrameworkCore;
using Scheduler.Web.Domain.Events.Entities;
using Scheduler.Web.Domain.Events.Queries;
using Scheduler.Web.Domain.Events.Repositories;
using Scheduler.Web.Infra.Data.Context;

namespace Scheduler.Web.Infra.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Add(Event _event)
        {
            _context.Events.Add(_event);
        }

        public void Update(Event _event)
        {
            _context.Events.Update(_event);
        }

        public Event GetById(Guid id) => _context.Events.FirstOrDefault(x => x.Id == id);

        public async Task<IEnumerable<EventQueryResult>> GetAll()
        {
            return await _context
                .Events
                .AsNoTracking()
                .Where(x => x.Active == true && !x.Deleted)
                .Select(x => new EventQueryResult
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Title = x.Title,
                    Description = x.Description,
                    Location = x.Location

                })
                .OrderBy(x => x.StartDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<EventQueryResult>> GetByDate(DateTime date)
        {
            return await _context
                .Events
                .AsNoTracking()
                .Where(x => x.Active == true
                        && !x.Deleted
                        && x.StartDate.Date == date.Date)
                .Select(x => new EventQueryResult
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Title = x.Title,
                    Description = x.Description,
                    Location = x.Location

                })
                .ToListAsync();
        }

        public async Task<EventQueryResult> GetByEvent(Guid id)
        {
            return await _context
                .Events
                .AsNoTracking()
                .Where(x => !x.Deleted)
                .Select(x => new EventQueryResult
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Title = x.Title,
                    Description = x.Description,
                    Location = x.Location
                })
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Delete(Event _event)
        {
            _context.Events.Remove(_event);
        }
    }
}
