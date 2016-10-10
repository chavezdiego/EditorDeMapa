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

            var Cursor = new Editor(ConsoleKey.A, ConsoleKey.D, ConsoleKey.W, ConsoleKey.S, ConsoleKey.Enter);

            Cursor.Init();

            bool fin=true;

            do
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    fin = Cursor.Eleccion(tecla);
                }

                Cursor.Dibujar();

                Pantalla.Dibujar();
            } while (fin);



            while (true)
            {
                //Pantalla.BorrarPantalla();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    Cursor.Mover(tecla);
                }

                Cursor.Dibujar();

                Escenario.Imprimir();

                Pantalla.Dibujar();
            }

        }
    }
}
