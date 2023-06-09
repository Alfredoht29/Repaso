using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repaso
{
    public class Suma : Operaciones,Interface
    {
        public int opera(int a, int b)
        {
            int c = a+b;
            return c;
        }
        public string xd(string name)
        {
            string s = $"Hola {name}";
            return s;
        }
    }
}
