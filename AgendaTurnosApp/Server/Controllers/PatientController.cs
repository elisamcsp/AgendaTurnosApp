using AgendaTurnosApp.Repositories;
using AgendaTurnosApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Patient>> Get()
        {
            return await _patientRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Patient> Get(int id)
        {
            return await _patientRepository.GetDetails(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest();
            if (string.IsNullOrEmpty(patient.FirstName))
                ModelState.AddModelError("FirstName", "Debe rellenar el campo Nombre");
            if (string.IsNullOrEmpty(patient.LastName))
                ModelState.AddModelError("LastName", "Debe rellenar el campo Apellidos");
            if (string.IsNullOrEmpty(patient.DNI))
                ModelState.AddModelError("LastName", "Debe rellenar el campo DNI/NIE/TIE");

            if (!ModelState.IsValid)
                return BadRequest();

            await _patientRepository.InsertPatient(patient);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest();
            if (string.IsNullOrEmpty(patient.FirstName))
                ModelState.AddModelError("FirstName", "Debe rellenar el campo Nombre");
            if (string.IsNullOrEmpty(patient.LastName))
                ModelState.AddModelError("LastName", "Debe rellenar el campo Apellidos");
            if (string.IsNullOrEmpty(patient.DNI))
                ModelState.AddModelError("LastName", "Debe rellenar el campo DNI/NIE/TIE");

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _patientRepository.UpdatePatient(patient);
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
           await _patientRepository.DeltePatient(id);
        }

    }
}