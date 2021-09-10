using System;
using System.Collections.Generic;
using System.Linq;

namespace WebExample.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<SpendsRecord> Spends { get; set; } = new List<SpendsRecord>();
    
        public Person()
        {
        }

        public Person(int id, string cpf, string name, double salary, DateTime birthDate)
        {
            this.Id = id;
            this.Cpf = cpf;
            this.Name = name;
            this.Salary = salary;
            this.BirthDate = birthDate;
        }

        public void AddSpend(SpendsRecord spend) => Spends.Add(spend);
        public void RemoveSpend(SpendsRecord spend) => Spends.Remove(spend);
        public double TotalSpends(DateTime initial, DateTime final) => Spends.Where(s => s.Date >= initial && s.Date <= final).Sum(s => s.Amount);
    }
}
