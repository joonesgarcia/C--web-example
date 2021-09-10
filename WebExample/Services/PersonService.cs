using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExample.Data;
using WebExample.Models;

namespace WebExample.Services
{
    public class PersonService
    {
        private readonly WebExampleContext _context;

        public PersonService(WebExampleContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Person.ToList();
        }
    }
}
