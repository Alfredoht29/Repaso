using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeWCF
{
    public class EmployeeServ : IEmployeeServ
    {
        public string RegistrarEmpleado(int id, string Name)
        {
            Empleado empleado = new Empleado(id,Name);
            return "Exito";
        }
    }
}
