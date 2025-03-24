using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreinAbo.Api.Contracts;
using TreinAbo.Services;

namespace TreinAbo.Api.Controllers
{
    [Route("api/stations")]
    [ApiController]
    public class StationController (IStationService service): ControllerBase
    {
                [HttpPost]
        public ActionResult<StationResponseContract> Create(
            [FromBody] StationRequestContract klantRequestContract)
        {
            var created = service.Create(klantRequestContract);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public ActionResult<StationResponseContract> Get([FromRoute] int id)
        {
            var customer = service.GetById(id);
            if (customer is null) return NotFound();
            return Ok(customer);
        }
        [HttpGet]
        public ActionResult<IEnumerable<StationResponseContract>> GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpPut("{id}")]
        public ActionResult Update(
        [FromBody] StationRequestContract customer,
        [FromRoute] int id)
        {
            service.Update(id, customer);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Update([FromRoute] int id)
        {
            service.Delete(id);
            return NoContent();
        }
    }
}
