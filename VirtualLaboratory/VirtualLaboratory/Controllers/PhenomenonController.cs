using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualLaboratory.Domain.ApiModels.Phenomenon;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhenomenonController : ControllerBase
    {
        private readonly IPhenomenonService _service;

        public PhenomenonController(IPhenomenonService service)
        {
            _service = service;
        }

        // GET: api/Phenomenon
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var phenomena = await _service.GetAllAsync();

                if(phenomena.Any())
                {
                    return Ok(phenomena);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/Phenomenon/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if(id > 0)
                {
                    var phenomenon = await _service.GetAsync(id);

                    if (phenomenon != null)
                    {
                        return Ok(phenomenon);
                    }

                    return NoContent();
                }

                return BadRequest("Некорректный id");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/Phenomenon
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddPhenomenonModel addPhenomenon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var phenomenonId = await _service.AddAsync(addPhenomenon);

                    return CreatedAtAction("GetAsync", new { id = phenomenonId }, addPhenomenon);
                }

                return BadRequest(addPhenomenon);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/Phenomenon/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdatePhenomenonModel updatePhenomenon)
        {
            try
            {
                if(id > 0)
                {
                    if (ModelState.IsValid)
                    {
                        var isUpdated = await _service.UpdateAsync(id, updatePhenomenon);

                        if (isUpdated)
                        {
                            return Ok();
                        }
                    }

                    return NoContent();
                }

                return BadRequest("Некорректный id");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/Phenomenon/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if(id > 0)
                {
                    var isDeleted = await _service.DeleteAsync(id);

                    if (isDeleted)
                    {
                        return Ok();
                    }

                    return NoContent();
                }

                return BadRequest("Некорректный id");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
