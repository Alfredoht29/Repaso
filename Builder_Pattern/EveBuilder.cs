using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Builder_Pattern
{
    public class EveBuilder : HumanoBuilder
    {
        public EveBuilder(int edad,int estatura,int peso) 
        {
            _humano = new Humano { Edad = edad, Estatura = estatura, Masa = peso };
        }
        public override void nombrar()
        {
            _humano.Nombre = "Eve";
        }
        public override void asignarGenero()
        {
            _humano.Sexo = "Mujer";
        }
    }
}
