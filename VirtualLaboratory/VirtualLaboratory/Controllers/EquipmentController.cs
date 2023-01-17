using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualLaboratory.Domain.ApiModels.Equipment;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _service;

        public EquipmentController(IEquipmentService service)
        {
            _service = service;
        }

        // GET: api/Equipment
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var equipments = await _service.GetAllAsync();

                if (equipments.Any())
                {
                    return Ok(equipments);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/Equipment/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var equipment = await _service.GetAsync(id);

                    if (equipment != null)
                    {
                        return Ok(equipment);
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

        // POST api/Equipment
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddEquipmentModel addEquipment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var equipmentId = await _service.AddAsync(addEquipment);

                    return CreatedAtAction("GetAsync", new { id = equipmentId }, addEquipment);
                }

                return BadRequest(addEquipment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/Equipment/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateEquipmentModel updateEquipment)
        {
            try
            {
                if (id > 0)
                {
                    var isUpdated = await _service.UpdateAsync(id, updateEquipment);

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

        // DELETE api/Equipment/5
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
