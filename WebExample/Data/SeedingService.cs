using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExample.Models;

namespace WebExample.Data
{
    public class SeedingService
    {
        private readonly WebExampleContext _context;

        public SeedingService(WebExampleContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Person.Any() ||
                _context.Segment.Any() ||
                _context.SpendsRecord.Any())
            {
                return;
            }
            Person p1 = new Person(1, "45309235841", "Joao Garcia", 2300, new DateTime(1998, 01, 30));
            Person p2 = new Person(2, "12332123454", "Felipe Diaz", 800, new DateTime(1990, 09, 30));
            Person p3 = new Person(3, "98337465382", "Amanda Santos Silva", 1000, new DateTime(1970, 11, 30));
            Person p4 = new Person(4, "22346578643", "Fernando de Moraes Filho", 400, new DateTime(1982, 06, 30));

            Segment sg1 = new Segment(1, "Alimentação");  
            Segment sg2 = new Segment(2, "Educação");
            Segment sg3 = new Segment(3, "Diversão");

            SpendsRecord sr1 = new SpendsRecord(1, "Mc Donalds", new DateTime(2001, 01, 01), 50, Models.Enums.SpendStatus.Cancelled, p1, sg1);
            SpendsRecord sr2 = new SpendsRecord(2, "Curso Ingles", new DateTime(2002, 01, 01), 200, Models.Enums.SpendStatus.Paid, p4, sg2);
            SpendsRecord sr3 = new SpendsRecord(3, "Mini curso de Java", new DateTime(2002, 09, 01), 50, Models.Enums.SpendStatus.Paid, p3, sg2);
            SpendsRecord sr4 = new SpendsRecord(4, "Cinema", new DateTime(2003, 05, 10), 75, Models.Enums.SpendStatus.Paid, p2, sg3);
            SpendsRecord sr5 = new SpendsRecord(5, "Carrinho de controle remoto", new DateTime(2003, 09, 01), 20, Models.Enums.SpendStatus.Pending, p1, sg3);

            _context.Person.AddRange(p1, p2, p3, p4);
            _context.Segment.AddRange(sg1, sg2, sg3);
            _context.SpendsRecord.AddRange(sr1, sr2, sr3, sr4, sr5);

            _context.SaveChanges();
        }
    }
}

