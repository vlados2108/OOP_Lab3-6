using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Persons
{
    public class Professor:Human
    {
        private int _numOfGroups;   
        public Professor(string name, int age, int numOfGroups) : base(name, age)
        {
            NumOfGroups = numOfGroups;
        }

        public int NumOfGroups
        {
            get => _numOfGroups;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество групп должно быть больше нуля");
                _numOfGroups = value;
            }
        }    
    }
}
