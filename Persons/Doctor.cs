using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Persons
{
    public class Doctor:Human,IDoctor
    {
        private int _patients_per_day;
        public string speciality { get; set; }

        public Doctor(string name, int age,int patients_per_day):base( name, age)
        {
            Patients_per_day = patients_per_day;
            this.speciality = GetSpeciality();
        }

        public int Patients_per_day
        {
            get => _patients_per_day;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество пациентов должно быть больше нуля");
                _patients_per_day = value;
            }
        }

        public virtual string GetSpeciality()
        {
            return "";
        }
    }
}
