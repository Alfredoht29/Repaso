using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Crudwpf
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Empleados> empleadosList = new List<Empleados> { new Empleados(1, "Angel", 25, "asdlsd") };
        public MainWindow()
        {
            InitializeComponent();
            this.Datagrid1.ItemsSource = empleadosList;
        }
        public void updatelist(Empleados empleado)
        {
            empleadosList.Add(empleado);
            refresh();
        }
        public void refresh()
        {
            this.Datagrid1.ItemsSource = null;
            this.Datagrid1.ItemsSource = empleadosList;
        }
        public void eliminar(int i)
        {
            empleadosList.RemoveAt(i);
            refresh();
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            IdBox.Clear();
            NameBox.Clear();
            AgeBox.Clear();
            EmailBox.Clear();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(IdBox.Text);
            string name = NameBox.Text;
            int age = Int32.Parse(AgeBox.Text);
            string email = EmailBox.Text;
            Empleados empleado = new Empleados(id, name, age, email);
            bool already_exist = empleadosList.Any(emp => emp.Id == id);
            if (already_exist)
            {
                var findit = empleadosList.Where(emp => emp.Id == id);
                foreach (Empleados emp in findit)
                {
                    emp.Name = empleado.Name;
                    emp.Age = empleado.Age;
                    emp.Email = empleado.Email;
                }
                refresh();
            }
            else
            {
                updatelist(empleado);
            }

        }

        private void Datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;
            if (e.AddedItems.Count > 0)
            {
                Empleados selectedRowData = (Empleados)e.AddedItems[0];
                id = selectedRowData.Id;
            }
            var SelectedToBox = empleadosList.Where(empleado => empleado.Id == id).ToList();
            foreach (var item in SelectedToBox)
            {
                IdBox.Text = item.Id.ToString();
                NameBox.Text = item.Name;
                AgeBox.Text = item.Age.ToString();
                EmailBox.Text = item.Email;
            }

        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(IdBox.Text);
            bool isempty = empleadosList.Any();
            if (isempty)
            {
                var findEliminar = empleadosList.FindIndex(n => n.Id == id);
                eliminar(findEliminar);
            }
            else
            {
                MessageBox.Show("No hay elementos en la lista");
            }
        }
    }
}
