using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    public class Hijo:Padre
    {
        


        public Hijo() : base() 
        {
            this.Name = "hijo";
        }
        
        public override void hello()
        {
            Console.WriteLine("hijo");
        }
    }
}
