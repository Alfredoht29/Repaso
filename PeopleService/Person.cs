using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PeopleService
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Email { get; set; }
        public Person(int id, string name, string lastname, int age, string email)
        {
            Id = id;
            Name = name;
            LastName = lastname;
            Age = age;
            Email = email;
        }
    }
}