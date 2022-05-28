using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Persons
{
    public class Programmer:Human
    {
        private int _salary;

        public Programmer(string name, int age, int salary) : base(name, age)
        {
            Salary = salary;
        }

        public int Salary
        {
            get => _salary;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Зарплата должна быть больше нуля");
                _salary = value;
            }
        }
    }
}
