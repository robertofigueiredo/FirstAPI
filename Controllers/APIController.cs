using Awesomedevevents.API.Entities;
using Awesomedevevents.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Awesomedevevents.API.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly DevEventsDbContext _context;
        public APIController(DevEventsDbContext context)
        {
            _context = context;
        }

        // api/dev-events GET

        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvents.Where(rr => !rr.IsDeleted).ToList();

            return Ok(devEvents);
        }

        // api/dev-events/23124343 GET

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(rr => rr.Id == id);

            if (devEvents == null)
            {
                return NotFound();
            }
            return Ok(devEvents);
        }

        // api/dev-events POST

        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);
            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }

        // api/dev-events/23124343 PUT

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent input)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(rr => rr.Id == id);

            if (devEvents == null)
            {
                return NotFound();
            }
            devEvents.Update(input.Title, input.Description, input.StartDate, input.EndDate);
            return NoContent();
        }

        // api/dev-events/2321313 DELETE

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(rr => rr.Id == id);
            if (devEvents == null)
            {
                return NotFound();
            }
            devEvents.Delete();

            return NoContent();
        }

        // api/dev-events/3fa85f64-5717-4562-b3fc-2c963f66afa6/speakers POST 

        [HttpPost("{id}/speakers")]
        public IActionResult PostSpeaker(Guid id, DevEventSpeaker speaker)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(rr => rr.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Speakers.Add(speaker);

            return NoContent();
        }
    }
}
