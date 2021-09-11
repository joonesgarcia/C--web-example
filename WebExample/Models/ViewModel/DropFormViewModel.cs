using System.Collections.Generic;
using WebExample.Models.Enums;

namespace WebExample.Models.ViewModel
{
    public class DropFormViewModel
    {
        public SpendsRecord Spend { get; set; }
        public SpendStatus Status { get; set; }
        public Segment Segment { get; set; }
        public Person Person { get; set; }
        public ICollection<Person> Persons { get; set; }
        public ICollection<Segment> Segments { get; set; }
        public ICollection<SpendsRecord> Spends { get; set; }
    }
}
