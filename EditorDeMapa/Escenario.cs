using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeMapa
{
    class Escenario
    {
        private Escenario()
        { 
        
        }

        static List<ObjEscenario> Mapa = new List<ObjEscenario>();

        static public void AgregarObjeto(ObjEscenario obj)
        {
            Mapa.Add(obj);
        }

        static public void Imprimir()
        {
            foreach (ObjEscenario obj in Mapa)
            {
                obj.Dibujar();
            }
        }

    }
}
