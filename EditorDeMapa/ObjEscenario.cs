using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeMapa
{
    abstract class ObjEscenario
    {
        public ObjEscenario()
        {
            
        }

        abstract public void VistaPrevia(int x, int y);

        abstract public void Borrar();

        abstract public void Dibujar();
        
    }
}
