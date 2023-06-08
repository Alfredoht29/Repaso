using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTestPeople
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PersonService" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PersonService.svc o PersonService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PersonService : IPersonService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

       
    }
}
