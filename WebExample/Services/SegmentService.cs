using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebExample.Data;
using WebExample.Models;
using WebExample.Services;
using WebExample.Services.Exceptions;

namespace WebExample.Services
{
    public class SegmentService
    {
        private readonly WebExampleContext _context; // creates a context dependency with Db

        public SegmentService(WebExampleContext context) => _context = context; //constructor

        public List<Segment> FindAll() => _context.Segment.ToList(); // uses context to return a List<> of Segments

        public Segment FindById(int id) => _context.Segment.FirstOrDefault(item => item.Id == id); // uses context to return a Segment by Id

        public void Insert(Segment s) // uses context to add a Segment
        {
            _context.Add(s);
            _context.SaveChanges();
        }
        public void Delete(Segment s) // uses context to delete a Segment
        {
            _context.Remove(s);
            _context.SaveChanges();
        }
        public void Update(Segment s)
        {
            if (!_context.Segment.Any(x => x.Id == s.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(s);
                _context.SaveChanges();
            }catch (DbUpdateConcurrencyException e) //intercepts a (data-access) layer exception and throws other one at (service) layer
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
