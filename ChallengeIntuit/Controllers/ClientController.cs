using ChallengeIntuit.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeIntuit.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {

        private readonly ClientsService _service;

        public ClientController(ClientsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<ClientsEntity> GetAll()
        {
            return _service.GetAll();
        }
    }
}
