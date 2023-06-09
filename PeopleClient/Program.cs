using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PeopleClient
{
    internal class Program
    {
        //Este programa hace uso de los wcf 
        static void Main(string[] args)
        {
            //ServiceProxy.PersonServiceClient serviceProxy = new ServiceProxy.PersonServiceClient();
            //var resultado = serviceProxy.GetData(2);
            //Console.WriteLine(resultado);
            //Console.ReadKey();
            //EmployeProxy.EmployeeServClient emp=new EmployeProxy.EmployeeServClient();
            //var a= emp.RegistrarEmpleado(12, "manuel");
            //Console.WriteLine(a);
            //Console.ReadKey();
            PersonSProxy.PersonServiceClient personlist = new PersonSProxy.PersonServiceClient();
            List<PersonSProxy.Person> plist = new List<PersonSProxy.Person>();
            var a = personlist.makeperson(1, "manuel", "Hernandez", 23, "asdsd");
            plist.Add(a);
            personlist.ProcessPersons(plist.ToArray());
            Console.ReadKey();
        }
    }
}
