using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle8Piezas
{
    public class Puzzle
    {
        public void getSolucion(Nodo inicio, int[,] solucion)
        {
            List<Nodo> expandidos = new List<Nodo>();
            expandidos.Add(inicio);

            while (expandidos.Count != 0)
            {
                Nodo revisar = expandidos[0];
                expandidos.RemoveAt(0);
                imprimirEstado(revisar.getEstado());
                int[] pcero = ubicarPosicionCero(revisar.getEstado());

            }

        }

        private int[] ubicarPosicionCero(int[,] estado)
        {
            int[] posicion = new int[2];
            for (int i = 0; i < estado.Length; i++)
            {
                for (int j = 0; j < estado.Length; j++)
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

        private void imprimirEstado(int[,] estado)
        {
            for(int i = 0; i < estado.Length; i++)
            {
                for(int j = 0; j < estado.Length; j++)
                {
                    Console.Write("[" + estado[i, j] + "]");
                }
                Console.WriteLine();
            }
        }
    }
}
