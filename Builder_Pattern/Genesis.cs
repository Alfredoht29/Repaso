using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public class Genesis
    {
        private HumanoBuilder _humanobuilder;
        public void crearhumano(HumanoBuilder humanobuilder)
        {
            _humanobuilder = humanobuilder;
        }
        public void crea()
        {
            _humanobuilder.nombrar();
            _humanobuilder.asignarGenero();
        }
        public Humano humanovivo
        {
            get { return _humanobuilder.GetHumano(); }
        }
    }
}
