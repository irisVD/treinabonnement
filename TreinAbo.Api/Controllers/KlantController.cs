using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreinAbo.Api.Contracts;
using TreinAbo.Services;

namespace TreinAbo.Api.Controllers
{
    [Route("api/klanten")]
    [ApiController]
    public class KlantController(IKlantService service) : ControllerBase
    {
        [HttpPost]
        public ActionResult<KlantResponseContract> Create(
            [FromBody] KlantRequestContract klantRequestContract)
        {
            var created = service.Create(klantRequestContract);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public ActionResult<KlantResponseContract> Get([FromRoute] int id)
        {
            var customer = service.GetById(id);
            if (customer is null) return NotFound();
            return Ok(customer);
        }
        [HttpGet]
        public ActionResult<IEnumerable<KlantResponseContract>> GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpPut("{id}")]
        public ActionResult Update(
        [FromBody] KlantRequestContract customer,
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
