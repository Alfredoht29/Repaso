﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MainViewModel()
        {
            Empleados = new ObservableCollection<Empleado> { new Empleado(1, "Angel", 25, "asdlsd") };
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

        public Empleado _Empleado
        {
            get
            {
                return _empleado;
            }
            set
            {
                _empleado = value;
                OnPropertyChanged("Empleado");
                if (Id !=0 && _empleado!=null )
                {
                    Id = _empleado.Id;
                    Name = _empleado.Name;
                    Age = _empleado.Age;
                    Email = _empleado.Email;
                }
            }
        }
        public void BorrarCommandExecute()
        {
            int findIndex = Empleados.IndexOf(Empleados.Where(n => n.Id == Id).FirstOrDefault());
            if (findIndex != -1) { Empleados.RemoveAt(findIndex); }
           
        }
        public void GuardarCommandExecute()
        {
            Empleado empleado = new Empleado(Id, Name, Age, Email);
            bool repated = Empleados.Any(n => n.Id == Id);
            if (repated)
            {
                var update = Empleados.Where(n => n.Id == empleado.Id);
                foreach (Empleado n in update)
                {
                    n.Name = empleado.Name;
                    n.Age = empleado.Age;
                    n.Email = empleado.Email;
                }

            }
            else
            {
                Empleados.Add(empleado);
            }
            Empleados = new ObservableCollection<Empleado>(Empleados);
        }
        public void NewCommandExecute()
        {
            Id = 0;
            Name = String.Empty;
            Age = 0;
            Email = String.Empty;
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

    }
}
