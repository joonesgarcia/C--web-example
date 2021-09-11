using System;
using System.ComponentModel.DataAnnotations;
using WebExample.Models.Enums;


namespace WebExample.Models
{
    public class SpendsRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }
        public SpendStatus Status { get; set; }
        public Person Person { get; set; }
        public Segment Segment { get; set; }
        public int SegmentId { get; set; }
        public int PersonId { get; set; }


        public SpendsRecord()
        {
        }

        public SpendsRecord(int id, string name, DateTime date, double amount, SpendStatus status, Person person, Segment segment)
        {
            Id = id;
            Name = name;
            Date = date;
            Amount = amount;
            Status = status;
            Person = person;
            Segment = segment;
        }
    }
}
