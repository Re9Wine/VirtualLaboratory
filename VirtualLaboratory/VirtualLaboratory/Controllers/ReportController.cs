using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualLaboratory.Domain.ApiModels.Report;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        // GET: api/Report
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var reports = await _service.GetAllAsync();

                if (reports.Any())
                {
                    return Ok(reports);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/Report/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if(id > 0)
                {
                    var report = await _service.GetAsync(id);

                    if(report != null)
                    {
                        return Ok(report);
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

        // POST api/Report
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddReportModel addReport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var reportId = await _service.AddAsync(addReport);

                    return CreatedAtAction("GetAsync", new { id = reportId }, addReport);
                }

                return BadRequest(addReport);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/Report/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateReportModel updateReport)
        {
            try
            {
                if(id > 0)
                {
                    var isUpdated = await _service.UpdateAsync(id, updateReport);

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

        // DELETE api/Report/5
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
