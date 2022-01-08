using AgendaTurnosApp.Repositories;
using AgendaTurnosApp.Shared.Entities;
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
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;            
        }

        [HttpGet]
        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _patientRepository.GetAll();
        }



    }
}
