using Microsoft.AspNetCore.Mvc;

namespace WebFront.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public ClientsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
