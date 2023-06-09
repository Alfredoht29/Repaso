using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    public class Padre
    {
        public string Name { get; set; } = "Padre";
        public int Edad { get; set; } = 40;
        public virtual void hello()
        {
            Console.WriteLine("hola");
        }
        public void xd()
        {
            Console.WriteLine("hola hijo");
        }
    }
}
