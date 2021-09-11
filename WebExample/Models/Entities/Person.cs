using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebExample.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Salary { get; set; }
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Total Spends")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TotalSpend { get; set; }
        public ICollection<SpendsRecord> Spends { get; set; } = new List<SpendsRecord>();
    
        public Person()
        {
        }
        public Person(int id, string cpf, string name, double salary, DateTime birthDate, double initialSpend)
        {
            Id = id;
            Cpf = cpf;
            Name = name;
            Salary = salary;
            BirthDate = birthDate;
            TotalSpend = initialSpend;
        }

        public void AddSpend(SpendsRecord spend) => Spends.Add(spend);
        public void RemoveSpend(SpendsRecord spend) => Spends.Remove(spend);
        public double TotalSpends(DateTime initial, DateTime final) => Spends.Where(s => s.Date >= initial && s.Date <= final).Sum(s => s.Amount);
        public double TotalSpendsUpdate() => TotalSpend = Spends.Where(s => this == s.Person).Sum(s => s.Amount);

    }
}
