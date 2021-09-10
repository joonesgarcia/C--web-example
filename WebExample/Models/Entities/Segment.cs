using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExample.Models
{
    public class Segment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SpendsRecord> Spends { get; set; } = new List<SpendsRecord>();

        public Segment()
        {
        }
        public Segment(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public double TotalSpends(DateTime initial, DateTime final)
        {
            return Spends.Where(s => 
                        Name == s.Segment.Name 
                        && s.Date >= initial 
                        && s.Date <= final).Sum(s => s.Amount);
        }
    }
}
