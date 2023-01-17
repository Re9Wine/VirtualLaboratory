using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualLaboratory.Domain.ApiModels.TheoreticalInformation;
using VirtualLaboratory.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheoreticalInformationController : ControllerBase
    {
        private readonly ITheoreticalInformationService _service;

        public TheoreticalInformationController(ITheoreticalInformationService service)
        {
            _service = service;
        }

        // GET: api/TheoreticalInformation
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var theoreticalInformation = await _service.GetAllAsync();

                if (theoreticalInformation.Any())
                {
                    return Ok(theoreticalInformation);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/TheoreticalInformation/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var theoreticalInformation = await _service.GetAsync(id);

                    if (theoreticalInformation != null)
                    {
                        return Ok(theoreticalInformation);
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

        // POST api/TheoreticalInformation
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddTheoreticalInformationModel addTheoreticalInformation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var constantId = await _service.AddAsync(addTheoreticalInformation);

                    return CreatedAtAction("GetAsync", new { id = constantId }, addTheoreticalInformation);
                }

                return BadRequest(addTheoreticalInformation);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/TheoreticalInformation/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateTheoreticalInformationModel updateTheoreticalInformation)
        {
            try
            {
                if (id > 0)
                {
                    var isUpdated = await _service.UpdateAsync(id, updateTheoreticalInformation);

                    if (isUpdated)
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

        // DELETE api/TheoreticalInformation/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (id > 0)
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
