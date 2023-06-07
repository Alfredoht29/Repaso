using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public class AdamBuilder:HumanoBuilder
    {
        public AdamBuilder(int edad, int estatura, int peso)
        {
            _humano = new Humano { Edad = edad, Estatura = estatura, Masa = peso };
        }
        public override void nombrar()
        {
            _humano.Nombre = "Adam";
        }
        public override void asignarGenero()
        {
            _humano.Sexo = "Hombre";
        }
    }
}
