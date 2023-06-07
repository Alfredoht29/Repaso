using System.Security.Claims;

namespace Classes_Struct_Record_net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class a = new Class(10, 10);
            Class b = a;
            Struct c = new Struct(10, 10);
            Struct bs = c;
            Record f=new Record(10, 10);
            Record g=f with { age=8080 };
            b.age = 15;
            c.age = 30;
            f.age = 30;
            f.id = 1;
            a.id = 2;
            //g.age = 30;
            Console.WriteLine($"class {b.age} y {b.id}");
            Console.WriteLine($"class {a.age} y  {a.id}");
            Console.WriteLine($"struct {bs.age}");
            Console.WriteLine($"Record {f.age} y {f.id}");
            Console.WriteLine($"Record {g.age} y {g.id}");
            Console.ReadLine();
        }
    }
}
