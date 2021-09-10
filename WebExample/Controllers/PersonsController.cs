using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExample.Services;
using WebExample.Data;
using WebExample.Models;

namespace WebExample.Controllers
{
    public class PersonsController : Controller
    {
        private readonly PersonService _personService;

        public PersonsController(PersonService personService) => _personService = personService;

        public IActionResult Index()
        {
            return View(_personService.FindAll());
        }
    }
}
