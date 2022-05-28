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
    /// Логика взаимодействия для Programmerview.xaml
    /// </summary>
    public partial class Programmerview : UserControl,IHumanView
    {
        public Programmerview()
        {
            InitializeComponent();
        }

        public void Set(Human human)
        {
            if (human is not Programmer programmer)
                throw new ArgumentException();

            Name.Text = programmer.Name;
            Age.Text = programmer.Age.ToString(CultureInfo.InvariantCulture);
            Salary.Text = programmer.Salary.ToString();
        }

        public event Action<Human> Confirmed;

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Confirmed?.Invoke(new Programmer(Name.Text,
                    Convert.ToInt32(Age.Text, CultureInfo.InvariantCulture),
                    int.Parse(Salary.Text)));
            }
            catch
            {
                MessageBox.Show("Некорректные данные!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
