using System.Collections.Generic;
using System.Linq;
using WebExample.Data;
using WebExample.Models;
using WebExample.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace WebExample.Services
{
    public class PersonService
    {
        private readonly WebExampleContext _context; // creates a context dependency with Db

        public PersonService(WebExampleContext context) => _context = context; // constructor

        public List<Person> FindAll() // uses context to return a List<> of People (Persons)
        {
            return _context.Person.ToList();
        }
        public Person FindById(int id) // uses context to return a Person by Id
        {
            return _context.Person.FirstOrDefault(item => item.Id == id);
        }
        public void Insert(Person p) // uses context to insert a Person
        {
            //_context.Add(p);
            _context.Person.Add(p);
            _context.SaveChanges();
        }
        public void Delete(int id) // uses context to delete a Person
        {
            var p = _context.Person.Find(id);
            _context.Remove(p);
            _context.SaveChanges();
        }
        public void Update(Person p)
        {
            if (!_context.Person.Any(x => x.Id == p.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(p);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) //intercepts a (data-access) layer exception and throws other one at (service) layer
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
