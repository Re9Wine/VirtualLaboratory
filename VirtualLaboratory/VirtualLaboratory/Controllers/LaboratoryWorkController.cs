using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualLaboratory.Domain.ApiModels.LaboratoryWork;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryWorkController : ControllerBase
    {
        private readonly ILaboratoryWorkService _service;

        public LaboratoryWorkController(ILaboratoryWorkService service)
        {
            _service = service;
        }

        // GET: api/LaboratoryWork
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var laboratoryWorks = await _service.GetAllAsync();

                if (laboratoryWorks.Any())
                {
                    return Ok(laboratoryWorks);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/LaboratoryWork/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var laboratoryWork = await _service.GetAsync(id);

                    if (laboratoryWork != null)
                    {
                        return Ok(laboratoryWork);
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

        // POST api/LaboratoryWork
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddLaboratoryWorkModel addLaboratoryWork)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var laboratoryWorkId = await _service.AddAsync(addLaboratoryWork);

                    return CreatedAtAction("GetAsync", new { id = laboratoryWorkId }, addLaboratoryWork);
                }

                return BadRequest(addLaboratoryWork);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/LaboratoryWork/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateLaboratoryWorkModel updateLaboratoryWork)
        {
            try
            {
                if (id > 0)
                {
                    var isUpdated = await _service.UpdateAsync(id, updateLaboratoryWork);

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

        // DELETE api/LaboratoryWork/5
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
