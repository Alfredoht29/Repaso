using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryAnalysis xx = new BinaryAnalysis();
            xx.analyse(96);

            //LinQrepaso linq = new LinQrepaso();
            //linq.count();

            //List<Person> personList = new List<Person>
            //{
            //    new Person("Test",2),
            //    new Person("Angel",10),
            //    new Person("Sergio",20),
            //    new Person("Emilio",30)
            //};
            //List<string> names = new List<string> { "Angel", "Sergio", "Emilio", "Carlos", "Lily" };
            //names.Remove("Angel");
            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}
            //var del = from result in personList where result.Name == "Test" select result;
            //Person persondel = new Person();
            //foreach (Person person in del)
            //{
            //    persondel.Name = person.Name;
            //    persondel.Age = person.Age;
            //    Console.WriteLine($"se encontro a {persondel.Name} y tiene {persondel.Age}");
            //}
            //personList.RemoveAt(0);
            //Console.WriteLine("En la lista estan");
            //foreach (var item in personList)
            //{
            //    Console.WriteLine($"{item.Name} y tiene {item.Age}");
            //}

            //ObservableCollection<string> nombres = new ObservableCollection<string> { "Angel", "Sergio", "Emilio", "Carlos", "Lily" };
            //nombres.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
            //{
            //    if (e.Action == NotifyCollectionChangedAction.Add)
            //    {
            //        Console.WriteLine("Nuevo nombre añadido");
            //    }
            //    else if (e.Action == NotifyCollectionChangedAction.Remove)
            //    {
            //        Console.WriteLine("Nombre Removido");
            //    }
            //};
            //foreach (string nom in nombres) {
            //    Console.WriteLine(nom);
            //}
            //nombres.Add("Test");
            //nombres.Remove("Carlos");

            //ObservableCollection<Person> personCollection = new ObservableCollection<Person> {
            //    new Person("Test", 2),
            //    new Person("Angel", 20),
            //    new Person("Emilio",20),
            //    new Person("Sergio",20)
            //    };
            //personCollection.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e)=>
            //{
            //    if (e.Action == NotifyCollectionChangedAction.Add)
            //    {
            //        Console.WriteLine("Persona añadida");
            //    }
            //    else if (e.Action == NotifyCollectionChangedAction.Remove)
            //    {
            //        Console.WriteLine("Persona Removida");
            //    }
            //};
            //Person personadd = new Person();
            //personadd.Name = "persona";
            //personadd.Age = 50;
            //personCollection.Add(personadd);
            //personCollection.RemoveAt(0);
            //foreach (Person person in personCollection)
            //{
            //    Console.WriteLine($"{person.Name} y tiene {person.Age}");
            //}
            Console.ReadLine();
        }
    }
}
