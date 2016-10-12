using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace EditorDeMapa
{
    class Editor
    {
        static Punto pos = new Punto();

        static ConsoleKey izq=ConsoleKey.LeftArrow, der=ConsoleKey.RightArrow, up=ConsoleKey.UpArrow, down=ConsoleKey.DownArrow, enter=ConsoleKey.Enter;
        static ConsoleKey guardar = ConsoleKey.G;

        static short obj = 0;

        static StringBuilder sb = new StringBuilder();


        static List<ObjEscenario> LObj = new List<ObjEscenario>();

        private Editor()
        {
        }

        public static void Init()
        {
            pos.x = 1;
            pos.y = 10;
            
            LObj.Add(new Obstaculo(0, 0));
            LObj.Add(new Plataforma(0, 0));
        }

        public static bool Eleccion(ConsoleKeyInfo tecla)
        {

            LObj[obj].Borrar();

            if (tecla.Key == up)
            {
                obj--;
            }

            if (tecla.Key == down)
            {
                obj++;
            }

            if (tecla.Key == enter)
            {
                return false;
            }

            return true;
        }

        public static void Mover(ConsoleKeyInfo tecla)
        {
            
            foreach (ObjEscenario obj in LObj)
            {
                obj.Borrar();
            }

            if (tecla.Key == izq)
            {
                pos.x--;
            }
            
            if (tecla.Key == der)
            {
                pos.x++;
            }
            
            if (tecla.Key == up)
            {
                pos.y--;
            }
            
            if (tecla.Key == down)
            {
                pos.y++;
            }
           
            if (tecla.Key == enter)
            {
                switch (obj)
                {
                    case 0: Escenario.AgregarObjeto(new Obstaculo(pos.x, (int)pos.y));
                        CrearMapa("Obs");
                        break;

                    case 1: Escenario.AgregarObjeto(new Plataforma(pos.x, (int)pos.y));
                        CrearMapa("Plat");
                        break;
                }

                

            }

            if (tecla.Key == guardar)
            {
                GuardarMapa("PrimerMapa");
            }

            if (tecla.Key == ConsoleKey.Delete)
            {
                Escenario.QuitarUltObjeto();
            }
            
        }

        static DateTime start = DateTime.Now;
        static short mostrar=0;

        public static void Dibujar()
        {

            if ((DateTime.Now - start).TotalMilliseconds >= 250)
            {
                if (mostrar == 0)
                {
                    LObj[obj].VistaPrevia(pos.x,(int)pos.y);
                    mostrar = 1;
                }
                else
                {
                    LObj[obj].Borrar();
                    mostrar = 0;
                }
                
                start = DateTime.Now;
            }
        }
        /*
        public static void BarraDeObjetos()
        {
            foreach (ObjEscenario obj in LObj)
            {
                obj.VistaPrevia(pos.x,(int)pos.y);
            }
        }
        */
        public static void Borrar()
        {
            Pantalla.Borrar(pos.x,(int)pos.y);
        }

        public static void CrearMapa(string objeto)
        {
            sb.Append(objeto + ":" + pos.x.ToString() + "," + pos.y.ToString() );
            sb.Append('\n');
        }

        public static void GuardarMapa(string nomb)
        {
            string Nombre = nomb;
            string tempurl = "C:\\Mapas\\" + Nombre + ".txt";

            File.WriteAllText(tempurl, sb.ToString());
        }

    }
}
