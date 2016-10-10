using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeMapa
{
    class Obstaculo:ObjEscenario
    {
        Punto pos = new Punto();

        int w = 2, h = 4;

        char[] img;
            
        public Obstaculo(int posX, int posY)
        {
            pos.x = posX;
            pos.y = posY;
        }
        
        override public void Dibujar()
        {

            int TamañoChar = w * h;

            img = new char[TamañoChar];

            for (int t = 0; t < TamañoChar; t++)
            {
                img[t] = 'X';
            }
            Pantalla.CargarAMatriz(img, w, h, pos.x, (int)pos.y);
        }

        override public void VistaPrevia(int x, int y)
        {
            pos.x = x;
            pos.y = y;

            int TamañoChar = w * h;

            img = new char[TamañoChar];

            for (int t = 0; t < TamañoChar; t++)
            {
                img[t] = 'X';
            }
            Pantalla.CargarAMatriz(img, w, h, pos.x, (int)pos.y);
        }

        override public void Borrar()
        {
            Pantalla.Borrar(w, h, pos.x, (int)pos.y);
        }
        
        public char[] ObtenerImagen()
        {
            return img;
        }

        public int ObtenerW()
        {
            return w;
        }

        public int ObtenerH()
        {
            return h;
        }
    }
}
