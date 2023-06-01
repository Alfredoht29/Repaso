using MVVM.ViewModel;
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

namespace MVVM
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel mainViewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.Datagrid1.ItemsSource = mainViewModel.empleados;
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            IdBox.Text = "";
            NameBox.Text = "";
            AgeBox.Text = "";
            EmailBox.Text = "";
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Empleado add = new Empleado();
            add.Id=Int32.Parse(IdBox.Text);
            add.Name = NameBox.Text;
            add.Email = EmailBox.Text;
            add.Age = Int32.Parse(AgeBox.Text);
            bool find= mainViewModel.empleados.Any(x => x.Id == add.Id);
            if (find)
            {
                mainViewModel.update(add);
                this.Datagrid1.Items.Refresh();
            }
            else
            {
                mainViewModel.add(add);
            }

        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            int Index = Int32.Parse(IdBox.Text);
            mainViewModel.delete(Index);
        }

        private void Datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;
            if (e.AddedItems.Count > 0)
            {
                Empleado selectedRowData = (Empleado)e.AddedItems[0];
                id = selectedRowData.Id;
            }
            var SelectedToBox = mainViewModel.empleados.Where(empleado => empleado.Id == id).ToList();
            foreach (var item in SelectedToBox)
            {
                IdBox.Text = item.Id.ToString();
                NameBox.Text = item.Name;
                AgeBox.Text = item.Age.ToString();
                EmailBox.Text = item.Email;
            }
        }
    }
}
