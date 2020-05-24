using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReedExpo.Ecom.Registrations.Models;
using ReedExpo.Ecom.Registrations.Services;

namespace ReedExpo.Ecom.Registrations.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/registrations")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationsService _service;

        public RegistrationsController(IRegistrationsService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> AddRegistration([FromBody] RegistrationRequest model)
        {
            var result = await _service.AddRegistration(model);

            return Ok(result);
        }

        [HttpGet("{registrationId}")]
        public async Task<IActionResult> AddRegistration(string registrationId)
        {
            var result = await _service.GetRegistration(registrationId);

            return Ok(result);
        }
    }


}