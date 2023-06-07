using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Test.Model;

namespace Test.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int? id;
        private string name;
        private int? age;
        private string email;
        private Empleado _empleado;
        private ObservableCollection<Empleado> empleados { get; set; }
        private ICommand newCommand;
        private ICommand guardarCommand;
        private ICommand borrarCommand;
        private ICommand rowClickCommand;
        private readonly SqlConnection cnt = DataAccess.Instance.DbConnection();

        public MainViewModel()
        {
            load();
        }
        public int? Id
        {
            get { return id; }
            set
            {
                if (value != id)
                    id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                    name = value;
                OnPropertyChanged("Name");
            }
        }
        public int? Age
        {
            get { return age; }
            set
            {
                if (value != age)
                    age = value;
                OnPropertyChanged("Age");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (value != email)
                    email = value;
                OnPropertyChanged("Email");
            }
        }
        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(p => NewCommandExecute());
                }
                return newCommand;
            }
        }
        public ICommand GuardarCommand
        {
            get
            {
                if (guardarCommand == null)
                {
                    guardarCommand = new RelayCommand(p => GuardarCommandExecute());
                }
                return guardarCommand;
            }
        }
        public ICommand BorrarCommand
        {
            get
            {
                if (borrarCommand == null)
                {
                    borrarCommand = new RelayCommand(p => BorrarCommandExecute());
                }
                return borrarCommand;
            }
        }
        public ICommand RowClickCommand
        {
            get
            {
                if (rowClickCommand == null)
                {
                    //rowClickCommand = new RelayCommand((p) => RowClickedExecute(p));
                    rowClickCommand = new RelayCommand<object>(RowClickedExecute);
                }
                return rowClickCommand;
            }
        }
        public Empleado _Empleado
        {
            get
            {
                return _empleado;
            }
            set
            {
                if (value != _empleado)
                    _empleado = value;
                OnPropertyChanged("_Empleado");
            }
        }
        public void BorrarCommandExecute()
        {
            //int findIndex = Empleados.IndexOf(Empleados.Where(n => n.Id == Id).FirstOrDefault());
            //if (findIndex != -1) { Empleados.RemoveAt(findIndex); }
            cnt.Open();
            string command = String.Format("exec dbo.DelEmpleados '{0}'", Id);
            SqlCommand delempleados = new SqlCommand(command, cnt);
            using (SqlDataReader reader = delempleados.ExecuteReader()) { }
            cnt.Close();
            load();
        }
        public void GuardarCommandExecute()
        {
            #region sindb
            //Empleado empleado = new Empleado(Id, Name, Age, Email);
            //bool repated = Empleados.Any(n => n.Id == Id);
            //if (repated)
            //{
            //    var update = Empleados.Where(n => n.Id == empleado.Id);
            //    foreach (Empleado n in update)
            //    {
            //        n.Name = empleado.Name;
            //        n.Age = empleado.Age;
            //        n.Email = empleado.Email;
            //    }

            //}
            //else if(Id!=null && Age!=null)
            //{
            //    Empleados.Add(empleado);
            //}
            //else
            //{
            //    MessageBox.Show("Corrige tus campos numericos");
            //}
            //Empleados = new ObservableCollection<Empleado>(Empleados);
            #endregion
            cnt.Open();
            if (Id == 0 || Id == null)
            {
                //string command = String.Format("exec dbo.InsEmpleado '{0}','{1}','{2}'",Name,Age,Email);
                //SqlCommand insempleados= new SqlCommand(command, cnt);
                SqlCommand insempleados = new SqlCommand("InsEmpleado",cnt);
                insempleados.CommandType = CommandType.StoredProcedure;
                insempleados.Parameters.Add("@Name",SqlDbType.NChar,85).Value=Name;
                insempleados.Parameters.Add("@Age",SqlDbType.Int).Value=Age;
                insempleados.Parameters.Add("@Email", SqlDbType.NChar, 100).Value = Email;
                using (SqlDataReader reader = insempleados.ExecuteReader()) { }
                cnt.Close();
                load();
            }
            else
            {
                // Insert and Select in one storedProcedure
                string command = String.Format("exec dbo.UpdEmpleados '{0}','{1}','{2}','{3}'", Id,Name, Age, Email);
                SqlCommand updempleados = new SqlCommand(command, cnt);
                using (SqlDataReader reader = updempleados.ExecuteReader()) {
                    while (reader.Read())
                    {
                        Empleado empleado = new Empleado();
                        empleado.Id = reader.GetInt32(0);
                        empleado.Name = reader.GetString(1);
                        empleado.Age = reader.GetInt32(2);
                        empleado.Email = reader.GetString(3);
                        Empleados.Add(empleado);
                    }
                }
                cnt.Close();
                load();
            }
        }
        public void NewCommandExecute()
        {
            Id = 0;
            Name = String.Empty;
            Age = 0;
            Email = String.Empty;
        }
        public void RowClickedExecute(object parameter)
        {
            if (!(parameter is Empleado))
                return;

            Empleado empSelected = (Empleado)parameter;
            Id = empSelected.Id;
            Name = empSelected.Name;
            Age = empSelected.Age;
            Email = empSelected.Email;
        }
        public ObservableCollection<Empleado> Empleados
        {
            get { return empleados; }
            set
            {
                if (value != empleados)
                    empleados = value;
                OnPropertyChanged("Empleados");
            }
        }

        public void load()
        {
            cnt.Open();
            SqlCommand getempleados = new SqlCommand("exec dbo.SelEmpleados", cnt);
            Empleados = new ObservableCollection<Empleado>();
            using (SqlDataReader reader = getempleados.ExecuteReader())
            {
                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.Id = reader.GetInt32(0);
                    empleado.Name = reader.GetString(1);
                    empleado.Age = reader.GetInt32(2);
                    empleado.Email = reader.GetString(3);
                    Empleados.Add(empleado);
                }
                cnt.Close();
            }
        }
    }
}
