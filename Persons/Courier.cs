using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Persons
{
    public class Courier:Human
    {
        private string _company;

        public Courier(string name, int age, string company) : base(name, age)
        {
            Company = company;
        }

        public string Company
        {
            get => _company;
            set
            {
                if (value == "")
                    throw new ArgumentException("Имя компании не может быть пустым");
                _company = value;
            }
        }
    }
}
