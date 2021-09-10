using System.Collections.Generic;
using System.Linq;
using WebExample.Data;
using WebExample.Models;

namespace WebExample.Services
{
    public class SpendsRecordsService
    {
        private readonly WebExampleContext _context; // creates a context dependency with Db

        public SpendsRecordsService(WebExampleContext context) => _context = context; //constructor

        public List<SpendsRecord> FindAll() => _context.SpendsRecord.ToList(); // uses context to return a List<> of SpendsRecord

        public SpendsRecord FindById(int id) => _context.SpendsRecord.FirstOrDefault(item => item.Id == id); // uses context to return a SpendsRecord by Id

        public void Insert(SpendsRecord s) // uses context to add a SpendsRecord
        {
            _context.Add(s);
            _context.SaveChanges();
        }
        public void Delete(SpendsRecord s) // uses context to delete a SpendsRecord
        {
            _context.Remove(s);
            _context.SaveChanges();
        }
    }
}
