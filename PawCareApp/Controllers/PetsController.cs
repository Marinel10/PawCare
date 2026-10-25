

namespace PawCare.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PawCare.ViewModels;

    public class PetsController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Create() => View();

        [HttpGet]
        public IActionResult Details(int id) => View();

        [HttpGet]
        public IActionResult Edit(int id) => View();

        [HttpGet]
        public IActionResult Delete(int id) => View();
    }
}
