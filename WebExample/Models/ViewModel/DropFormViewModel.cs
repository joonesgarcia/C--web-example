using System.Collections.Generic;
using WebExample.Models.Enums;

namespace WebExample.Models.ViewModel
{
    public class DropFormViewModel
    {
        public SpendsRecord Spend { get; set; }
        public ICollection<Person> Persons { get; set; }
        public ICollection<Segment> Segments { get; set; }
        public ICollection<SpendStatus> Status { get; set; }
    }
}
