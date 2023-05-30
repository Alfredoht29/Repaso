using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    public class BinaryAnalysis
    {
        public void analyse(int number)
        {
            int contador=0;
            int resultado=0;
            String set=Convert.ToString(number,2);
            char[] setarr = set.ToCharArray();
            for(int i = 0; i<=setarr.Length; i++) {
                if (i != setarr.Length)
                {
                    if (setarr[i] == '0')
                    {
                        contador += 1;
                    }
                    else if (setarr[i] == '1')
                    {
                        if (contador > resultado)
                        {
                            resultado = contador;
                        }
                        contador = 0;
                    }
                }
                else
                {
                    if (contador > resultado)
                    {
                        resultado = contador;
                    }
                }
            }
            Console.WriteLine($"Resultado: {resultado}");
        }
    }
}
