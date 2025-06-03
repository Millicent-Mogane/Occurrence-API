
using Microsoft.AspNetCore.Mvc;
using OccurrenceApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace OccurrenceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OccurrencesController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Dictionary<string, int>> Post([FromBody] OccurrenceRequest request)
        {
            if (request.Items == null || request.Items.Count == 0)
                return BadRequest("Items list cannot be empty.");

            var result = request.Items
                                .GroupBy(item => item)
                                .ToDictionary(g => g.Key, g => g.Count());

            return Ok(result);
        }
    }
}
