using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Persons
{
    public class Bankir:Human
    {
        private string _bank;

        public Bankir(string name, int age, string bank) : base(name, age)
        {
            Bank = bank;
        }

        public string Bank
        {
            get => _bank;
            set
            {
                if (value == "")
                    throw new ArgumentException("Имя банка не может быть пустым");
                _bank = value;
            }
        }
    }
}
