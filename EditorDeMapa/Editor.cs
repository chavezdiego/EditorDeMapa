using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EditorDeMapa
{
    class Editor
    {
        Punto pos = new Punto();

        ConsoleKey izq, der, up, down, enter;

        short obj = 0;

        static List<ObjEscenario> LObj = new List<ObjEscenario>();

        //static Obstaculo obs = new Obstaculo(0, 0);
        //static Plataforma plat = new Plataforma(0, 0);

        public Editor(ConsoleKey tecla_izq, ConsoleKey tecla_der, ConsoleKey tecla_up, ConsoleKey tecla_down,ConsoleKey tecla_enter)
        {
            izq = tecla_izq;
            der = tecla_der;
            up = tecla_up;
            down = tecla_down;
            enter = tecla_enter;
        
            pos.x = 1;
            pos.y = 10;

            
        }

        public void Init()
        {
            LObj.Add(new Obstaculo(0, 0));
            LObj.Add(new Plataforma(0, 0));

        }

        public bool Eleccion(ConsoleKeyInfo tecla)
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

        public void Mover(ConsoleKeyInfo tecla)
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
                        break;

                    case 1: Escenario.AgregarObjeto(new Plataforma(pos.x, (int)pos.y));
                        break;
                }

            }
        }

        static DateTime start = DateTime.Now;
        short mostrar=0;

        public void Dibujar()
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

        public void Borrar()
        {
            Pantalla.Borrar(pos.x,(int)pos.y);
        }

    }
}
