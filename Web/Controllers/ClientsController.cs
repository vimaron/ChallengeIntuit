using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Web.Controllers
{
    public class ClientsController : Controller
    {

        public IActionResult Clients()
        {
            return View();
        }
    }
}