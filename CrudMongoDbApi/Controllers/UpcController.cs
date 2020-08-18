using CrudMongoDbApi.Models;
using CrudMongoDbApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudMongoDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpcsController : ControllerBase
    {
        private readonly UpcService _upcService;

        public UpcsController(UpcService upcService)
        {
            _upcService = upcService;
        }

        [HttpGet]
        public ActionResult<List<Upc>> Get() =>
            _upcService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUpc")]
        public ActionResult<Upc> Get(string id)
        {
            var upc = _upcService.Get(id);

            if (upc == null)
            {
                return NotFound();
            }

            return upc;
        }

        [HttpPost]
        public ActionResult<Upc> Create(Upc upc)
        {
            _upcService.Create(upc);

            return CreatedAtRoute("GetUpc", new { id = upc.Id.ToString() }, upc);
        }

         [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Upc upcIn)
        {
            var upc = _upcService.Get(id);

            if (upc == null)
            {
                return NotFound();
            }

            _upcService.Update(id, upcIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var upc = _upcService.Get(id);

            if (upc == null)
            {
                return NotFound();
            }

            _upcService.Remove(upc.Id);

            return NoContent();
        }

    }
}