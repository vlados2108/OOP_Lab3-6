using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Persons
{
    public abstract class Human
    {
        private string _name;
        private int _age;

        protected Human(string name, int age)
        {
            Name = name;
            Age = age;
        }
       
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Имя не может быть пустым");
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Возраст должен быть больше нуля");
                _age = value;
            }
        }
    }
}
