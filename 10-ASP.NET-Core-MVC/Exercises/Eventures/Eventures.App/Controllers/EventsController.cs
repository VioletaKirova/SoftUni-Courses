namespace Eventures.App.Controllers
{
    using Eventures.App.Models.BindingModels;
    using Eventures.App.Models.ViewModels;
    using Eventures.Data;
    using Eventures.Domain;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;
    using System.Linq;

    public class EventsController : Controller
    {
        private readonly EventuresDbContext dbContext;

        public EventsController(EventuresDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(EventCreateBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                Event eventForDb = new Event
                {
                    Name = model.Name,
                    Place = model.Place,
                    Start = model.Start,
                    End = model.End,
                    TotalTickets = model.TotalTickets,
                    PricePerTicket = model.PricePerTicket
                };

                this.dbContext.Events.Add(eventForDb);
                this.dbContext.SaveChanges();

                return this.RedirectToAction("All");
            }

            return this.View(model);
        }

        public IActionResult All()
        {
            var events = this.dbContext.Events.Select(eventFromDb => new EventAllViewModel
            {
                Name = eventFromDb.Name,
                Place = eventFromDb.Place,
                Start = eventFromDb.Start.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                End = eventFromDb.End.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)
            })
                .ToList();

            return View(events);
        }
    }
}