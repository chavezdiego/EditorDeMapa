using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeMapa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(101, 46);

            Console.SetWindowSize(100, 45);

            Console.CursorVisible = false;

            Editor.Init();

            //ModoEleccion();
            
            // Menu Principal
            bool salir=true;

            do
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    Menu.Principal(tecla);
                    if (tecla.Key == ConsoleKey.Escape)
                    {
                        salir = false;
                    }
                }
                Menu.Visualizar();

                Escenario.Imprimir();

            } while (salir);
            /*
            while (true)
            {
                //Pantalla.BorrarPantalla();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    Editor.Mover(tecla);
                    if (tecla.Key == ConsoleKey.Escape)
                    {
                        ModoEleccion();
                    }
                }

                Editor.Dibujar();

                Escenario.Imprimir();

                Pantalla.Dibujar();
            }
            */
        }

        static public void ModoEleccion()
        {
            bool fin = true;

            do
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    fin = Editor.Eleccion(tecla);
                }

                Editor.Dibujar();

                Pantalla.Dibujar();
            } while (fin);
        }

    }
}
