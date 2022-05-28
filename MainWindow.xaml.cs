using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
//using System.Text.Json;
using System.Text.Json.Serialization;
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
using WpfApp1.Views;
using PluginBaseLib;
using PluginLib;
using System.Runtime;
using WpfApp1.Commands;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PluginManager pm = new PluginManager();

        private readonly IDictionary<Type, (string Name, Func<IHumanView> CreateFunc)> _viewCreators =
        new Dictionary<Type, (string, Func<IHumanView>)>
        {
            {typeof(Doctor), ("Doctor", () => new DoctorView())},
            {typeof(Professor), ("Professor", () => new ProfessorView())},
            {typeof(Programmer), ("Programmer", () => new Programmerview())},
            {typeof(Courier), ("Courier", () => new CourierView())},
            {typeof(Bankir), ("Bankir", () => new BankirView())}
        };

        public ObservableCollection<Human> Humans { get; private set; } = new();
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBox();
            DataContext = this;
            pm.ScanPlugins(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\");
            foreach (var plugin in pm.Plugins)
            {
                var item = ArchiveComboBox.Items.Add(plugin.Name);
            }        
        }

        private void InitializeComboBox()
        {
            HumanComboBox.Items.Clear();
            foreach (var comboBoxItem in _viewCreators.Values.Select(c => new ComboBoxItem { Content = c.Name }))
            {
                HumanComboBox.Items.Add(comboBoxItem);
            }

            HumanComboBox.SelectedIndex = 0;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var view = _viewCreators.Skip(HumanComboBox.SelectedIndex).First().Value.CreateFunc();
            ListBox.SelectedIndex = -1;
            SelectView(view);
            view.Confirmed += t =>
            {
                Humans.Add(t);
                ListBox.SelectedIndex = Humans.Count - 1;
            };
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex >= 0)
            {
                var index = ListBox.SelectedIndex;
                Humans.RemoveAt(index);

                if (Humans.Count > index)
                    ListBox.SelectedIndex = index;
                else if (Humans.Count > 0)
                    ListBox.SelectedIndex = index - 1;
            }
        }

        private void ResetView()
        {
            ViewContainer.Child = null;
        }

        private void SelectView(IHumanView view)
        {
            ViewContainer.Child = (UserControl)view;
        }

        private void SerializeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string jsontext = JsonConvert.SerializeObject(Humans, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                File.WriteAllText("Data.json", jsontext);
                File.WriteAllText("Data\\Data.json", jsontext);
                MessageBox.Show("Сериализация была успешна завершена.\nДанные были сохранены в файл Data.json.", "Сериализация",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка при записи в файл Data.json!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при сериализации!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeserializeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {              
                string JsonString = File.ReadAllText("Data.json");             
                ListBox.ItemsSource = Humans = JsonConvert.DeserializeObject<ObservableCollection<Human>>(JsonString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                MessageBox.Show("Десериализация была успешна завершена.", "Десериализация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка при чтении файла Data.json!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при десериализации!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HumanComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResetView();

            if (ListBox.SelectedIndex >= 0)
            {
                var t = Humans[ListBox.SelectedIndex];
                if (_viewCreators.TryGetValue(t.GetType(), out var creator))
                {
                    var view = creator.CreateFunc();
                    SelectView(view);
                    view.Set(t);

                    view.Confirmed += human =>
                    {
                        var index = ListBox.SelectedIndex;
                        Humans[index] = human;
                        ListBox.SelectedIndex = index;

                        MessageBox.Show("Запись была изменена! ", "Изменение",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    };
                }
            }

        }

        private void CompressBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //foreach (var plugin in pm.Plugins)
                //{
                //    if (plugin.Name == ArchiveComboBox.Text)
                //    {
                //        plugin.CompressFile("Data", "");
                //    }
                //}
                Invoker invoker = new Invoker();
                foreach (var plugin in pm.Plugins)
                {
                    invoker.SetCommand(new PluginCommand(plugin));
                    if (plugin.Name == ArchiveComboBox.Text)
                        invoker.ExecuteCommand();
                    
                }

               

                MessageBox.Show("Архивация произошла успешно! ", "Архивация",
                       MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при сжатии файла Data.json!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        

        private void ArchiveComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    
}
