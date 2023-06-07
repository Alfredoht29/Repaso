using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlReader;

namespace XmlReader
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Configurations.Instance.getConfig();
            var i = Configurations.Instance.getConfigMachine();
            //config.getConfig();
            //config = config.getConfigMachine();
            //var i = config;
            Console.WriteLine(i.Machine);
            Console.WriteLine(i.Code);
            Console.WriteLine(i.filter);
            Console.ReadLine();
        }
    }
}
