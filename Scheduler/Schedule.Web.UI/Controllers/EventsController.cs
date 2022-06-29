using Microsoft.AspNetCore.Mvc;
using Scheduler.Web.Application.Interfaces;
using Scheduler.Web.Domain.Events.Commands;

namespace Schedule.Web.UI.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventAppService _eventsAppService;
        public EventsController(IEventAppService eventsAppService)
        {
            _eventsAppService = eventsAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _eventsAppService.GetAll());
        }

        [HttpGet("events/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("events/create")]
        public async Task<IActionResult> Create(AddEventCommand command)
        {
            await _eventsAppService.Add(command);
            return RedirectToAction("Index");
        }

        [HttpGet("events/edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var result = await _eventsAppService.GetById(id.Value);

            if (result == null) return NotFound();

            return View(result);
        }

        [HttpPost("events/edit")]
        public async Task<IActionResult> Edit(UpdateEventCommand command)
        {
            await _eventsAppService.Update(command);
            return RedirectToAction("Index");
        }

        [HttpGet("events/delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var result = await _eventsAppService.GetById(id.Value);

            if (result == null) return NotFound();

            return View(result);
        }

        [HttpPost("events/delete/{id:guid}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _eventsAppService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
