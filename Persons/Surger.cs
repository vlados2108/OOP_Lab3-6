using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Persons
{
    public class Surger:DoctorDecorator
    {

        public Surger(IDoctor doctor) :base(doctor){}

        public override string GetSpeciality()
        {
            string speciality = base.GetSpeciality();
            speciality += "Хирург";
            return speciality;
        }
    }
    public class Optometrist : DoctorDecorator
    {

        public Optometrist(IDoctor doctor) : base(doctor) { }

        public override string GetSpeciality()
        {
            string speciality = base.GetSpeciality();
            speciality += "Окулист";
            return speciality;
        }
    }
}
