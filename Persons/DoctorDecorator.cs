using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Persons
{
    public abstract class DoctorDecorator:IDoctor
    {
        protected IDoctor doctor;
        public DoctorDecorator(IDoctor doctor)
        {
            this.doctor = doctor;
        }

        public virtual string GetSpeciality()
        {
            return doctor.GetSpeciality();
        }
    }
}
