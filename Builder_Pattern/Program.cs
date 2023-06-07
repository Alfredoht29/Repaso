using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Genesis genesis = new Genesis();
            genesis.crearhumano(new EveBuilder(12, 160, 50));
            genesis.crea();
            var xd = genesis.humanovivo;
            genesis.crearhumano(new AdamBuilder(12, 170, 65));
            genesis.crea();
            var xd2 = genesis.humanovivo;
            Console.WriteLine($" Este humano es {xd.Nombre} tiene {xd.Edad} años, pesa {xd.Masa} mide {xd.Estatura} y es {xd.Sexo}");
            Console.WriteLine($" Este humano es {xd2.Nombre} tiene {xd2.Edad} años, pesa {xd2.Masa} mide {xd2.Estatura} y es {xd2.Sexo}");
            Console.ReadKey();
        }
    }
}
