using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeMapa
{
    class Menu
    {
        private Menu()
        {
    
        }

        static int modo = 0;
        static int y=5;

        static char[] Editor1 = { 'E', 'D', 'I', 'T', 'O', 'R' };
        static char[] Cargar = { 'C', 'A', 'R', 'G', 'A', 'R' };
        static char[] Crear = { 'C', 'R', 'E', 'A', 'R'};
        static char[] Jugar = { 'J', 'U', 'G', 'A', 'R' };
        static char[] Modo = { 'M', 'O', 'D', 'O' };
        static char[] Puntero = { '-' };

        static public int ObtenerModo()
        {
            return modo;
        }

        static public void Principal(ConsoleKeyInfo tecla)
        {
            if (tecla.Key == ConsoleKey.UpArrow)
            {
                Pantalla.Borrar(17,y);
                y=y-3;
                modo--;
            }

            if (tecla.Key == ConsoleKey.DownArrow)
            {
                Pantalla.Borrar(17, y);
                y=y+3;
                modo++;
            }

            if (tecla.Key == ConsoleKey.Enter)
            {
                switch (modo)
                {
                    case 0: 
                        break;
                    case 1: Editor.Mapas();
                        break;
                    case 2: Editor.PropMapa();
                        break;
                }
            }
        }

        static public void Visualizar()
        {
            Pantalla.CargarAMatriz(Puntero, 1, 1, 17, y);

            Pantalla.CargarAMatriz(Jugar, 5, 1, 10, 5);

            Pantalla.CargarAMatriz(Cargar, 6, 1, 10, 8);

            Pantalla.CargarAMatriz(Editor1,6,1,10,11);

            Pantalla.CargarAMatriz(Modo, 4, 1, 25, 5);

            Console.SetCursorPosition(30,5);
            Console.WriteLine(modo);

            Pantalla.Dibujar();
        }

    }
}
