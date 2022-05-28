using System;
using System.Collections.Generic;
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
using System.Globalization;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для ProfessorView.xaml
    /// </summary>
    public partial class ProfessorView : UserControl,IHumanView
    {
        public ProfessorView()
        {
            InitializeComponent();
        }

        public void Set(Human human)
        {
            if (human is not Professor professor)
                throw new ArgumentException();

            Name.Text = professor.Name;
            Age.Text = professor.Age.ToString(CultureInfo.InvariantCulture);
            NumOfGroups.Text = professor.NumOfGroups.ToString(CultureInfo.InvariantCulture);
        }

        public event Action<Human> Confirmed;

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Confirmed?.Invoke(new Professor(Name.Text,
                    Convert.ToInt32(Age.Text, CultureInfo.InvariantCulture),
                   Convert.ToInt32(NumOfGroups.Text, CultureInfo.InvariantCulture)));
            }
            catch
            {
                MessageBox.Show("Некорректные данные!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
