using AgendaTurnosApp.Repositories.Shifts;
using AgendaTurnosApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftController(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Shift>> Get()
        {
            return await _shiftRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Shift> Get(int id)
        {
            return await _shiftRepository.GetDetails(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shift Shift)
        {
            if (Shift == null)
                return BadRequest();
            if (Shift.PatientId == 0)
                ModelState.AddModelError("PatientId", "Debe seleccionar el Paciente");
            if (Shift.DoctorId == 0)
                ModelState.AddModelError("DoctorId", "Debe seleccionar el Doctor");

            if (!ModelState.IsValid)
                return BadRequest();

            await _shiftRepository.InsertShift(Shift);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Shift Shift)
        {
            if (Shift == null)
                return BadRequest();
            if (Shift.PatientId == 0)
                ModelState.AddModelError("PatientId", "Debe seleccionar el Paciente");
            if (Shift.DoctorId == 0)
                ModelState.AddModelError("DoctorId", "Debe seleccionar el Doctor");

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _shiftRepository.UpdateShift(Shift);
                return NoContent();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _shiftRepository.DelteShift(id);
        }
    }
}
