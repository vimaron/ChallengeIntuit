using ChallengeIntuit.Services;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeIntuit.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ClientsService _service;

        public ClientController(ClientsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<List<ClientsEntity>> GetAll()
        {
            return await _service.GetAll();
        }
    }
}
