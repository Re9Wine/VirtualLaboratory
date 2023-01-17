using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualLaboratory.Domain.ApiModels.MistakeInReport;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MistakeInReportController : ControllerBase
    {
        private readonly IMistakeInReportService _service;

        public MistakeInReportController(IMistakeInReportService service)
        {
            _service = service;
        }

        // GET: api/MistakeInReport
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var mistakes = await _service.GetAllAsync();

                if (mistakes.Any())
                {
                    return Ok(mistakes);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/MistakeInReport/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var mistake = await _service.GetAsync(id);

                    if (mistake != null)
                    {
                        return Ok(mistake);
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

        // POST api/MistakeInReport
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddMistakeInReportModel addMistake)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var equipmentId = await _service.AddAsync(addMistake);

                    return CreatedAtAction("GetAsync", new { id = equipmentId }, addMistake);
                }

                return BadRequest(addMistake);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/MistakeInReport/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateMistakeInReportModel updateMistake)
        {
            try
            {
                if (id > 0)
                {
                    var isUpdated = await _service.UpdateAsync(id, updateMistake);

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

        // DELETE api/MistakeInReport/5
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
