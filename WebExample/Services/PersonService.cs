using System.Collections.Generic;
using System.Linq;
using WebExample.Data;
using WebExample.Models;

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
            _context.Add(p);
            _context.SaveChanges();
        }
        public void Delete(int id) // uses context to delete a Person
        {
            var p = _context.Person.Find(id);
            _context.Remove(p);
            _context.SaveChanges();
        }
    }
}
