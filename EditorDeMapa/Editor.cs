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

        static int obj = 0;

        static int y = 5;

        static string NomMapa;

        static char[] Puntero = { '-' };

        static int yNombres=5;

        static StreamWriter escribir;
        //static StreamWriter escribir = File.AppendText("Mapa2.txt");

        static StreamReader lectura;

        static string[] campos = new string[3];
        
        static char[] separador = {','};

        static string MapaGuardado;

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
                Editor.CrearObjeto();
            }

            if (tecla.Key == guardar)
            {
                escribir.Close();
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
     
        public static void Borrar()
        {
            Pantalla.Borrar(pos.x,(int)pos.y);
        }

        public static void CrearMapa(string objeto)
        {
            escribir.WriteLine(objeto + "," + pos.x.ToString() + "," + pos.y.ToString());
        }
     
        public static void LeerMapa(string Mapa)
        {
            lectura = File.OpenText(Mapa + ".txt");

            MapaGuardado = lectura.ReadLine();

            while (MapaGuardado!=null)
            {
                CargarMapa();
                MapaGuardado = lectura.ReadLine();
            }

            lectura.Close();
        }

        public static void Mapas()
        {
            lectura = File.OpenText("NombresMapas.txt");

            string MapasNombre = lectura.ReadLine();

            while (MapasNombre != null)
            {
                Pantalla.CargarAMatriz(MapasNombre,50,yNombres);
                MapasNombre = lectura.ReadLine();
                yNombres = yNombres + 3;
            }

            lectura.Close();

            Pantalla.Dibujar();

            Console.WriteLine("Ingrese el nombre del mapa elegido: ");
            NomMapa = Console.ReadLine();

            LeerMapa(NomMapa);
        }
        
        public static void CargarMapa()
        {
            campos = MapaGuardado.Split(separador);
            
            Editor.CargarObjeto(Convert.ToInt32(campos[0].Trim()));
            
        }

        public static void CrearObjeto()
        {
            switch (obj)
            {
                case 0: Escenario.AgregarObjeto(new Obstaculo(pos.x, (int)pos.y));
                    CrearMapa("0");
                    break;

                case 1: Escenario.AgregarObjeto(new Plataforma(pos.x, (int)pos.y));
                    CrearMapa("1");
                    break;
            }
        }

        public static void CargarObjeto(int obj)
        {
            switch (obj)
            {
                case 0: Escenario.AgregarObjeto(new Obstaculo(Convert.ToInt32(campos[1].Trim()), Convert.ToInt32(campos[2].Trim())));
                    break;

                case 1: Escenario.AgregarObjeto(new Plataforma(Convert.ToInt32(campos[1].Trim()), Convert.ToInt32(campos[2].Trim())));
                    break;
            }

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

            while (true)
            {
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
        }

        static public void PropMapa()
        {
            Console.WriteLine("Ingrese un nombre: ");

            NomMapa = Console.ReadLine();

            escribir = File.AppendText("NombresMapas.txt");

            escribir.WriteLine(NomMapa);

            escribir.Close();

            escribir = File.AppendText(NomMapa + ".txt");

            Editor.ModoEleccion();
        }
        //static StringBuilder sb = new StringBuilder();

        /*
     public static void GuardarMapa(string nomb)
     {
         string Nombre = nomb;
         string tempurl = "C:\\Mapas\\" + Nombre + ".txt";

         File.WriteAllText(tempurl, sb.ToString());
     }
     */

        /*
        public static void CrearMapa(string objeto)
        {
            sb.Append(objeto + ":" + pos.x.ToString() + "," + pos.y.ToString() );
            sb.Append('\n');
        }
        */
    }
}
