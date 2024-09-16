using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProjects addProjects;
        private readonly IServiceEmail serviceEmail;

        public HomeController(ILogger<HomeController> logger,
            IRepositorioProjects addProjects, IServiceEmail serviceEmail)
        {
            _logger = logger;
            this.addProjects = addProjects;
            this.serviceEmail = serviceEmail;
        }

        public IActionResult Index()
        {
            _logger.LogTrace("Mensaje de trace");
            _logger.LogDebug("Mensaje de LogDebug");
            _logger.LogInformation("Mensaje de LogInformation");
            _logger.LogWarning("Mensaje de LogWarning");
            _logger.LogError("Mensaje de LogError");
            _logger.LogCritical("Mensaje de LogCritical");

            var projects = addProjects.ObtainProjects().Take(3).ToList();
            var model = new HomeIndexViewModel
            {
                Projects = projects,
            };

            var person = new PersonViewModel()
            {
                Name = "Bruno Perez",
            };

            var combinedModel = new CombinedViewModel
            {
                HomeModel = model,
                Person = person,
            };

            return View(combinedModel);
        }


        public IActionResult Projects()
        {
            var projects = addProjects.ObtainProjects().ToList();
            return View(projects);
        }

        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel contactViewModel)
        {
            await serviceEmail.Send(contactViewModel);
            return RedirectToAction("ThanksMessage");
        }

        public IActionResult ThanksMessage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
