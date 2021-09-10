using Microsoft.AspNetCore.Mvc;
using WebExample.Models;
using WebExample.Services;

namespace WebExample.Controllers
{
    public class SpendsRecordsController : Controller
    {

        private readonly SpendsRecordsService _spendsRecordsService; //dependency with SpendsRecordsService

        public SpendsRecordsController(SpendsRecordsService spendsRecordsService) => _spendsRecordsService = spendsRecordsService;

        public IActionResult Index() //uses a service to get SpendsRecords List<> and redirects it to index view
        {
            return View(_spendsRecordsService.FindAll());
        }
        public IActionResult Insert() /// redirects to insert view
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Insert(SpendsRecord s) // uses a service to insert a SpendsRecords to db and redirects to index view
        {
            _spendsRecordsService.Insert(s);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) // redirects to delete view
        {
            if (id == null) return NotFound();

            var p = _spendsRecordsService.FindById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(SpendsRecord s) // uses a service to insert a segment to db and redirects to index view
        {
            _spendsRecordsService.Delete(s);
            return RedirectToAction(nameof(Index));
        }

    }
}
