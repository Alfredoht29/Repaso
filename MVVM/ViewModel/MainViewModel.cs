using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MVVM.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<Empleado> empleados { get; set; }
        public ICommand ShowWindowCommand { get; set; }
        public MainViewModel()
        {
            empleados=EmpleadoManager.getEmpleados();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

        }
        public void add(Empleado empleado)
        {
            EmpleadoManager.AddEmpleado(empleado);
        }
        public void update(Empleado empleado)
        {
            EmpleadoManager.updtEmpleado(empleado);
        }

        public void delete(int index)
        {
            int findit = empleados.IndexOf(empleados.Where(n=>n.Id==index).FirstOrDefault());
            EmpleadoManager.delEmpleado(findit);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }
        private void ShowWindow(object obj)
        {
            throw new NotImplementedException();
        }

    }
}
