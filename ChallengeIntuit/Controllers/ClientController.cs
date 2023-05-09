using ChallengeIntuit.Services;
using Data.Dto;
using Data.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChallengeIntuit.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ClientsService _service;
        private readonly ILogger _log;

        public ClientController(ClientsService service,
            ILogger<ClientController> log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet]
        [Route("clients/{id:int}")]
        public async Task<IActionResult> GetById(
            [FromRoute] int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpGet]
        [Route("client/{name}")]
        public async Task<IActionResult> GetByName(
            [FromRoute] string name)
        {
            return Ok(await _service.GetByName(name));
        }

        [HttpPost]
        [Route("clients")]
        public async Task<IActionResult> Create([FromBody, Required] ClientCreateCriteria request)
        {

            try
            {
                _log.LogInformation("Create Client");
                return Ok(await _service.Create(
                request.Name,
                request.LastName,
                request.BirthDate,
                request.CUIT,
                request.Address,
                request.PhoneNumber,
                request.Mail
                ));
            }
            catch (ClientAlreadyExistsException ex)
            {
                _log.LogError(ex, "Error Log: {ex.Message}", ex.Message);
                ModelState.AddModelError("Name", ex.Message);
                return BadRequest(ModelState);
            }
           
        }

        [HttpPatch]
        [Route("clients")]
        public async Task<IActionResult> Update([FromBody, Required] ClientUpdateCriteria request)
        {
            try
            {
                await _service.Update(
                    request
                    );
                return Ok();
            }
            catch (ClientAlreadyExistsException ex)
            {
                _log.LogError(ex, "Error Log: {ex.Message}", ex.Message);
                ModelState.AddModelError("Name", ex.Message);
                return BadRequest(ModelState);
            }
            catch (ClientNotFoundException)
            {
                ModelState.AddModelError("Id", "Does Not exists!");
                return BadRequest(ModelState);
            }
        }
    }
}
