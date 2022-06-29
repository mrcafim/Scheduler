using Microsoft.AspNetCore.Mvc;
using Scheduler.Web.Application.Interfaces;
using Scheduler.Web.Domain.Events.Queries;

namespace Schedule.Web.UI.Controllers
{
    public class SchedulerController : Controller
    {
        private readonly IEventAppService _eventsAppService;
        public SchedulerController(IEventAppService eventsAppService)
        {
            _eventsAppService = eventsAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _eventsAppService.GetByDate(DateTime.Now));
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<EventQueryResult>> Get(DateTime date)
        {
            var events = await _eventsAppService.GetByDate(date);

            return events;
        }
    }
}
