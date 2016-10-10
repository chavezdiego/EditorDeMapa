using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeMapa
{
    class Plataforma:ObjEscenario
    {
        Punto pos = new Punto();
        int w=5, h=3;

        public Plataforma(int posX, int posY)
        {
            pos.y = posY;
            pos.x = posX;
        }

        override public void Dibujar()
        {
            int TamañoChar = w * h;

            char[] img = new char[TamañoChar];

            for (int t = 0; t < TamañoChar; t++)
            {
                img[t] = '#';
            }
            Pantalla.CargarAMatriz(img, w, h, pos.x, (int)pos.y);

        }

        override public void VistaPrevia(int x, int y)
        {
            pos.x = x;
            pos.y = y;
            
            int TamañoChar = w * h;

            char[] img = new char[TamañoChar];

            for (int t = 0; t < TamañoChar; t++)
            {
                img[t] = '#';
            }
            Pantalla.CargarAMatriz(img, w, h, pos.x, (int)pos.y);

        }

        override public void Borrar()
        {
            Pantalla.Borrar(w,h,pos.x,(int)pos.y);
        }
    }
}
