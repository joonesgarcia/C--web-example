using System.Collections.Generic;
using System.Linq;
using WebExample.Data;
using WebExample.Models;
using Microsoft.EntityFrameworkCore;
using WebExample.Services.Exceptions;

namespace WebExample.Services
{
    public class SpendsRecordsService
    {
        private readonly WebExampleContext _context; // creates a context dependency with Db

        public SpendsRecordsService(WebExampleContext context) => _context = context; //constructor

        public List<SpendsRecord> FindAll() => _context.SpendsRecord.Include(ob => ob.Segment).Include(obj => obj.Person).ToList(); // uses context to return a List<> of (SpendsRecord join Segment)
        public SpendsRecord FindById(int id) => _context.SpendsRecord.Include(obj => obj.Segment).Include(obj => obj.Person).FirstOrDefault(item => item.Id == id); // uses context to return (SpendsRecord join Segment) by Id

        public void Insert(SpendsRecord s) // uses context to add a SpendsRecord
        {
            // _context.Add(s);
            _context.SpendsRecord.Add(s);
            _context.SaveChanges();
        }
        public void Delete(SpendsRecord s) // uses context to delete a SpendsRecord
        {
            _context.Remove(s);
            _context.SaveChanges();
        }
        public void Update(SpendsRecord ss)
        {
            if (!_context.SpendsRecord.Any(x => x.Id == ss.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(ss);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) //intercepts a (data-access) layer exception and throws other one at (service) layer
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
