using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualLaboratory.Domain.ApiModels.Constant;
using VirtualLaboratory.Domain.Entity;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstantController : ControllerBase
    {
        private readonly IConstantService _service;

        public ConstantController(IConstantService service)
        {
            _service = service;
        }

        // GET: api/ConstantController
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var constants = await _service.GetAllAsync();

                if(constants.Any())
                {
                    return Ok(constants);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<ConstantController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if(id > 0)
                {
                    var constant = await _service.GetAsync(id);

                    if(constant != null)
                    {
                        return Ok(constant);
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

        // POST api/<ConstantController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddConstantModel addConstant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var constantId = await _service.AddAsync(addConstant);

                    return CreatedAtAction("GetAsync", new { id = constantId }, addConstant);
                }

                return BadRequest(addConstant);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/Constant/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateConstantModel updateConstant)
        {
            try
            {
                if(id > 0)
                {
                    var isUpdated = await _service.UpdateAsync(id, updateConstant);

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

        // DELETE api/Constant/5
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
