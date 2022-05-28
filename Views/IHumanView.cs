using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Persons;

namespace WpfApp1.Views
{
    public interface IHumanView
    {
        void Set(Human human);
        event Action<Human> Confirmed;
    }
}
