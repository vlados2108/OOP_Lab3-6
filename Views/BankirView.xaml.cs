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
    /// Логика взаимодействия для BankirView.xaml
    /// </summary>
    public partial class BankirView : UserControl,IHumanView
    {
        public BankirView()
        {
            InitializeComponent();
        }
        public void Set(Human human)
        {
            if (human is not Bankir bankir)
                throw new ArgumentException();

            Name.Text = bankir.Name;
            Age.Text = bankir.Age.ToString(CultureInfo.InvariantCulture);
            Bank.Text = bankir.Bank;
        }

        public event Action<Human> Confirmed;

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Confirmed?.Invoke(new Bankir(Name.Text,
                    Convert.ToInt32(Age.Text, CultureInfo.InvariantCulture),
                    Bank.Text));
            }
            catch
            {
                MessageBox.Show("Некорректные данные!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
