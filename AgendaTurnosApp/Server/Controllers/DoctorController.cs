using AgendaTurnosApp.Repositories;
using AgendaTurnosApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Doctor>> Get()
        {
            return await _doctorRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Doctor> Get(int id)
        {
            return await _doctorRepository.GetDetails(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            if (doctor == null)
                return BadRequest();
            if (string.IsNullOrEmpty(doctor.FirstName))
                ModelState.AddModelError("FirstName", "Debe rellenar el campo Nombre");
            if (string.IsNullOrEmpty(doctor.LastName))
                ModelState.AddModelError("LastName", "Debe rellenar el campo Apellidos");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _doctorRepository.InsertDoctor(doctor);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Doctor doctor)
        {
            if (doctor == null)
                return BadRequest();
            if (string.IsNullOrEmpty(doctor.FirstName))
                ModelState.AddModelError("FirstName", "Debe rellenar el campo Nombre");
            if (string.IsNullOrEmpty(doctor.LastName))
                ModelState.AddModelError("LastName", "Debe rellenar el campo Apellidos");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _doctorRepository.UpdateDoctor(doctor);
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
            await _doctorRepository.DelteDoctor(id);
        }
    }
}
