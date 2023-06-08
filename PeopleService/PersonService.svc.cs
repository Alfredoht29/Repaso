using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PeopleService
{
    public class PersonService : IPersonService
    {
        public Person makeperson(int id, string name, string lastname, int age, string email)
        {
            Person person = new Person(id,name,lastname,age,email);
            return person;
        }

        public void ProcessPersons(List<Person> persons)
        {

            foreach (var person in persons)
            {
                Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Last Name: {person.LastName}, Age: {person.Age}, Email: {person.Email}");
            }
        }
    }
}
