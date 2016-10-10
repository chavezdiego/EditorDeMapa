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

        static public void QuitarUltObjeto()
        {
            Mapa[Mapa.Count - 1].Borrar();
            Mapa.RemoveAt(Mapa.Count-1);
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
