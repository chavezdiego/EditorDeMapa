using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeMapa
{
    class Pantalla
    {
        private Pantalla()
        {
        }

        static Punto pos = new Punto();

        static char[,] Matriz = new char[900, 45];

        static int XMedio = 0;

        public static void CargarAMatriz(char[] img, int Weight, int Height, int X, int Y)
        {

            short posi = 0;

            for (int i = Y; i < Y + Height; i++)
            {
                for (int e = X; e < X + Weight; e++)
                {

                    Matriz[e, i] = img[posi];
                    posi++;

                }
            }

        }

        public static void CargarAMatriz(char img, int X, int Y)
        {
            Matriz[X, Y] = img;
        }

        public static void Borrar(int Weight, int Height, int X, int Y)
        {
            short posi = 0;

            int TamañoChar = Weight * Height;

            char[] img = new char[TamañoChar];

            for (int t = 0; t < TamañoChar; t++)
            {
                img[t] = ' ';
            }

            for (int i = Y; i < Y + Height; i++)
            {
                for (int e = X; e < X + Weight; e++)
                {
                    Matriz[e, i] = img[posi];
                    posi++;
                }

            }


        }

        public static void BorrarPantalla()
        {
            short posi = 0;

            char[] img = { ' ' };

            for (int i = 0; i < 45; i++)
            {
                for (int e = 0; e < 900; e++)
                {
                    Matriz[e, i] = img[0];
                    posi++;
                }
            }
        }

        public static void Borrar(int X, int Y)
        {
            char[] img = { ' ' };

            Matriz[X, Y] = img[0];
        }

        public static void Dibujar()
        {
            pos.x = 0;
            pos.y = 0;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 45; i++)
            {
                pos.x = 0;
                for (int e = XMedio; e < 100 + XMedio; e++) //Cambiar "e" Para mover pantalla
                {
                    if (Matriz[e, i] != '*')
                        sb.Append(Matriz[e, i]);
                    else
                        sb.Append(' ');
                    /*
                    {
                        Console.SetCursorPosition(pos.x, (int)pos.y);
                        Console.WriteLine(Matriz[e, i]);

                    }*/
                    pos.x++;
                }
                pos.y++;
                sb.Append('\n');
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());

        }
    }
}
