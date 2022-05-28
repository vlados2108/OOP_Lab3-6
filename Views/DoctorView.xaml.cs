using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Persons;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для DoctorView.xaml
    /// </summary>
    public partial class DoctorView : UserControl,IHumanView
    {
        public DoctorView()
        {
            InitializeComponent();
        }

        public void Set(Human human)
        {
          
            if (human is not Doctor doctor)
                throw new ArgumentException();

            Name.Text = doctor.Name;
            Age.Text = doctor.Age.ToString(CultureInfo.InvariantCulture);
            Patients_per_day.Text = doctor.Patients_per_day.ToString();
            if (doctor.speciality == "Хирург")
                SpecialityComboBox.SelectedIndex = 0;
            else
                SpecialityComboBox.SelectedIndex = 1;
        }

        public event Action<Human> Confirmed;

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IDoctor childDoc;
                if (SpecialityComboBox.Text == "Хирург")
                {
                    IDoctor doctor = new Doctor(Name.Text,
                    Convert.ToInt32(Age.Text, CultureInfo.InvariantCulture),
                    int.Parse(Patients_per_day.Text));
                    childDoc = new Surger(doctor);
                }
                else
                {
                   IDoctor doctor = new Doctor(Name.Text,
                   Convert.ToInt32(Age.Text, CultureInfo.InvariantCulture),
                   int.Parse(Patients_per_day.Text));
                    childDoc = new Optometrist(doctor);
                }
                Doctor doc = new Doctor(Name.Text,
                    Convert.ToInt32(Age.Text, CultureInfo.InvariantCulture),
                    int.Parse(Patients_per_day.Text));
                doc.speciality = childDoc.GetSpeciality();
                Confirmed?.Invoke(doc);
              
            }
            catch
            {
                MessageBox.Show("Некорректные данные!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
