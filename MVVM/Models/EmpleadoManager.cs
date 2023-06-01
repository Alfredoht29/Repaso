using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class EmpleadoManager
    {
        public static ObservableCollection<Empleado> empleados= new ObservableCollection<Empleado> { new Empleado(1, "Angel", 25, "asdlsd"), new Empleado(2, "Carlos", 25, "asdlsd") };

        public static ObservableCollection<Empleado> getEmpleados()
        {
            return empleados;
        }
        public static void AddEmpleado(Empleado empleado)
        {
            empleados.Add (empleado);
        }
        public static void delEmpleado(int id)
        {
            empleados.RemoveAt (id);
        }
        public static void updtEmpleado(Empleado empleado)
        {
            var update = empleados.Where(n=>n.Id==empleado.Id);
            foreach (Empleado n in update)
            {
                n.Name= empleado.Name;
                n.Age=empleado.Age;
                n.Email=empleado.Email;
            }
        }
    }
}
