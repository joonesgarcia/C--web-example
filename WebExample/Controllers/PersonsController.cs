using Microsoft.AspNetCore.Mvc;
using WebExample.Services;
using WebExample.Models;
using WebExample.Models.ViewModel;
using WebExample.Services.Exceptions;

namespace WebExample.Controllers
{
    public class PersonsController : Controller
    {
        private readonly PersonService _personService; //dependency with PersonService

        public PersonsController(PersonService personService) =>_personService = personService;
        
        public IActionResult Index() //uses a service to get persons List<> and passes it to index view with persons spends updated
        {
            foreach (Person p in _personService.FindAll()) 
            {
                p.TotalSpendsUpdate();
            }
            return View(_personService.FindAll());
        }
        public IActionResult Insert() //redirects to insert view 
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Insert(Person p) // uses service to insert to db and redirects to index view
        {
            _personService.Insert(p);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) // confirms id selected is not null and redirects to confirm delete view
        {
            if (id == null) return NotFound();

            var p = _personService.FindById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id) // uses service to delete a person by id from db and redirects to index view
        {
            _personService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)  // returns pretended obj to be reviewed at edit view
        {
            if (id == null) return NotFound();

            var obj = _personService.FindById(id.Value);

            if (obj == null) return NotFound();

            return View(obj);               
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Person p)
        {
            if (id != p.Id) return BadRequest();
            try
            {
                _personService.Update(p);
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
