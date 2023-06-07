using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public class Humano
    {
        public string Nombre { get; set;}
        public int Estatura { get; set; }
        public int Masa { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }

        public Humano() { }
        public Humano(string nombre, int estatura, int masa, int edad, string sexo)
        {
            Nombre = nombre;
            Estatura = estatura;
            Masa = masa;
            Edad = edad;
            Sexo = sexo;
        }
    }
}
