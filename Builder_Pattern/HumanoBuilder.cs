using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public abstract class HumanoBuilder
    {
        protected Humano _humano;
        public int Edad { get; set; }
        public int Estatura { get; set; }
        public int Masa { get; set; }
        public Humano GetHumano() { return _humano; }
        public virtual void nombrar() { }
        public virtual void asignarGenero() { }
    }
}
