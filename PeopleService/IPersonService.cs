using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PeopleService
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        void ProcessPersons(List<Person> persons);
        [OperationContract]
        Person makeperson(int id, string name, string lastname, int age, string email);
    }
}
