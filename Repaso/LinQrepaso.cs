using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    public class LinQrepaso
    {
        ObservableCollection<Person> personCollection = new ObservableCollection<Person> {
                new Person("Test", 2),
                new Person("Angel", 20),
                new Person("Emilio",20),
                new Person("Sergio",30),
                new Person("Andres",20)
                };
        public void count()
        {
            var count = personCollection.Count();
            Console.WriteLine(count);
        }
        public void first()
        {
            var first=(from person in personCollection select person).First();
            Console.WriteLine($"{first.Name} {first.Age}");
        }
        public void last()
        {
          var last=personCollection.Last();
            Console.WriteLine($"{last.Name} {last.Age}");
        }
        public void min()
        {
            var min=personCollection.Select(person=>person.Age).Min();
            Console.WriteLine($"{min}");
        }
        public void max()
        {
            var max=(from person in personCollection select person.Age ).Max();
            Console.WriteLine($"{max}");
        }
        public void avg()
        {
            var avg=(from person in personCollection select person.Age).Average();
            Console.WriteLine($"{avg}");
        }
        public void sum()
        {
            var sum=(from person in personCollection select person.Age).Sum();
            Console.WriteLine($"{sum}");
        }
        public void distinct()
        {
            var distinct=(from person in personCollection select person.Age).Distinct();
            foreach(int i in distinct)
            {
                Console.WriteLine(i);
            }
        }
        public void group()
        {
            var group=from person in personCollection group person by person.Age;
            foreach(var persongroup in group)
            {
                foreach (var person in persongroup)
                {
                    Console.WriteLine($"{person.Name} {person.Age}");
                }
            }
        }
        public void selwhere()
        {
            var w = personCollection.Where(person => person.Age==2);
            foreach(var person in w)
            {
                Console.WriteLine(person.Name);
                Console.WriteLine(person.Age);
            }
        }
    }
}
