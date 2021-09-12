using Microsoft.AspNetCore.Mvc;
using WebExample.Models;
using WebExample.Services;
using WebExample.Models.ViewModel;
using WebExample.Models.Enums;
using WebExample.Services.Exceptions;

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

        public IActionResult Index() 
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
        public IActionResult Insert(DropFormViewModel s) // uses a service to insert a SpendsRecords to db and redirects to index view
        {
            _spendsRecordsService.Insert(s.Spend);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)  // returns pretended obj to be reviewed at edit view
        {
            if (id == null) return NotFound();

            var obj = _spendsRecordsService.FindById(id.Value);

            var segments = _segmentService.FindAll();
            var persons = _personService.FindAll();

            if (obj == null) return NotFound();

            var dropViewModel = new DropFormViewModel { Persons = persons, Segments = segments , Spend = obj};

            return View(dropViewModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, DropFormViewModel df)
        {
            if (id != df.Spend.Id) return BadRequest();
            try
            {
                _spendsRecordsService.Update(df.Spend);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

    }
}
