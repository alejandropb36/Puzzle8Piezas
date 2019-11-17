using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle8Piezas
{
    public class Puzzle
    {
        public Nodo getSolucion(Nodo inicio, int[,] solucion)
        {
            List<Nodo> expandidos = new List<Nodo>();
            List<Nodo> visitados = new List<Nodo>();
            Nodo nulo = new Nodo(inicio.getEstado());
            expandidos.Add(inicio);
            int cont = 0;
            while (expandidos.Count != 0)
            {
                Nodo revisar = expandidos[0];
                expandidos.RemoveAt(0);
                imprimirEstado(revisar.getEstado());
                int[] pcero = ubicarPosicionCero(revisar.getEstado());

                Console.WriteLine("Iteracion: " + (++cont));

                if (CompareArray(revisar.getEstado(), solucion))
                {
                    return revisar;
                }

                
                visitados.Add(revisar);
                if(pcero[0] != 0)
                {
                    Nodo hijo = new Nodo(clonar(revisar.getEstado()));
                    int arriba = hijo.getEstado()[pcero[0] - 1, pcero[1]];

                    hijo.getEstado()[pcero[0], pcero[1]] = arriba;
                    hijo.getEstado()[pcero[0] - 1, pcero[1]] = 0;
                    if (!estaEnVisistados(visitados, hijo))
                    {
                        hijo.setPadre(revisar);
                        revisar.getHijos().Add(hijo);
                        expandidos.Add(hijo);
                    }
                }

                if (pcero[0] != 2)
                {
                    Nodo hijo = new Nodo(clonar(revisar.getEstado()));
                    int abajo = hijo.getEstado()[pcero[0] + 1, pcero[1]];

                    hijo.getEstado()[pcero[0], pcero[1]] = abajo;
                    hijo.getEstado()[pcero[0] + 1, pcero[1]] = 0;
                    if (!estaEnVisistados(visitados, hijo))
                    {
                        hijo.setPadre(revisar);
                        revisar.getHijos().Add(hijo);
                        expandidos.Add(hijo);
                    }
                }

                if (pcero[1] != 0)
                {
                    Nodo hijo = new Nodo(clonar(revisar.getEstado()));
                    int izquierda = hijo.getEstado()[pcero[0], pcero[1] - 1];

                    hijo.getEstado()[pcero[0], pcero[1]] = izquierda;
                    hijo.getEstado()[pcero[0], pcero[1] - 1] = 0;
                    if (!estaEnVisistados(visitados, hijo))
                    {
                        hijo.setPadre(revisar);
                        revisar.getHijos().Add(hijo);
                        expandidos.Add(hijo);
                    }
                }

                if (pcero[1] != 2)
                {
                    Nodo hijo = new Nodo(clonar(revisar.getEstado()));
                    int derecha = hijo.getEstado()[pcero[0], pcero[1] + 1];

                    hijo.getEstado()[pcero[0], pcero[1]] = derecha;
                    hijo.getEstado()[pcero[0], pcero[1] + 1] = 0;
                    if (!estaEnVisistados(visitados, hijo))
                    {
                        hijo.setPadre(revisar);
                        revisar.getHijos().Add(hijo);
                        expandidos.Add(hijo);
                    }
                }
            }
            return nulo;
        }

        private bool estaEnVisistados(List<Nodo> visitados, Nodo hijo)
        {
            foreach(Nodo nodo in visitados)
            {
                if(CompareArray(nodo.getEstado(), hijo.getEstado())){
                    return true;
                }
            }
            return false;
        }

        private bool CompareArray(int[,] v, int[,] v2)
        {
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    if(v[i,j] != v2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private int[,] clonar(int[,] estado)
        {
            int[,] clon = new int[estado.GetLength(0), estado.GetLength(1)];
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                    clon[i, j] = estado[i, j];
                }
            }
            return clon;
        }

        private int[] ubicarPosicionCero(int[,] estado)
        {
            int[] posicion = new int[2];
            for (int i = 0; i < estado.GetLength(0); i++)
            {
                for (int j = 0; j < estado.GetLength(1); j++)
                {
                   if(estado[i, j] == 0)
                    {
                        posicion[0] = i;
                        posicion[1] = j;
                    }
                }
            }
            return posicion;
        }

        public void imprimirEstado(int[,] estado)
        {
            for(int i = 0; i < estado.GetLength(0); i++)
            {
                for(int j = 0; j < estado.GetLength(1) ; j++)
                {
                    Console.Write("[" + estado[i, j] + "]");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------");
        }
    }
}
