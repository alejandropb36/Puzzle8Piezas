using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle8Piezas
{
    public class Nodo
    {
        private int[,] estado;
        private List<Nodo> hijos;
        private Nodo padre;

        public Nodo()
        {
            this.estado = new int[3,3];
            padre = null;
            hijos = new List<Nodo>();
        }

        public Nodo(int[,] estado)
        {
            this.estado = estado;
            padre = null;
            hijos = new List<Nodo>();
        }

        public int[,] getEstado()
        {
            return this.estado;
        }

        public void setEstado(int[,] estado)
        {
            this.estado = estado;
        }

        public Nodo getPadre()
        {
            return this.padre;
        }

        public void setPadre(Nodo padre)
        {
            this.padre = padre;
        }

        public List<Nodo> getHijos()
        {
            return this.hijos;
        }

        public void setHijos(List<Nodo> hijos)
        {
            this.hijos = hijos;
        }
    }
}
