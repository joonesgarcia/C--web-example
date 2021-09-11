using Microsoft.AspNetCore.Mvc;
using WebExample.Models;
using WebExample.Services;
using WebExample.Models.ViewModel;


namespace WebExample.Controllers
{
    public class SpendsRecordsController : Controller
    {

        private readonly SpendsRecordsService _spendsRecordsService; //dependency with SpendsRecordsService
        
        private readonly SegmentService _segmentService; //dependency with SpendsRecordsService
        private readonly PersonService _personService; //dependency with SpendsRecordsService

        public SpendsRecordsController(SpendsRecordsService spendsRecordsService, SegmentService segmentService, PersonService personService)
        {
            _spendsRecordsService = spendsRecordsService;
            _segmentService = segmentService;
            _personService = personService;

        }
        public IActionResult Index() //uses a service to get SpendsRecords List<> and redirects it to index view
        {
            return View(_spendsRecordsService.FindAll());
        }
        public IActionResult Insert() /// redirects to insert  with person and segment view models
        {
            var segments = _segmentService.FindAll();
            var persons = _personService.FindAll();

            var dropViewModel = new DropFormViewModel { Persons = persons , Segments = segments};

            return View(dropViewModel);
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
