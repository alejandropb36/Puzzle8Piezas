using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Puzzle8Piezas
{
    public partial class Form1 : Form
    {
        int[,] solucion;
        int[,] inicio;
        Nodo nodoInicio;
        Nodo nodoSolucion;
        Puzzle puzzle;
        Stack<Nodo> stackSolucion;

        public Form1()
        {
            InitializeComponent();
            solucion = new int[,]{ { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            inicio = new int[3, 3];
            nodoInicio = new Nodo();
            puzzle = new Puzzle();
            stackSolucion = new Stack<Nodo>();
        }

        private void getStackSolucion(Nodo nodoSolucion)
        {
            while (nodoSolucion.getPadre() != null)
            {
                stackSolucion.Push(nodoSolucion);
                nodoSolucion = nodoSolucion.getPadre();
            }
        }

        private void obtenerDatos()
        {
            inicio[0, 0] = int.Parse(button1.Text);
            inicio[0, 1] = int.Parse(button2.Text);
            inicio[0, 2] = int.Parse(button3.Text);
            inicio[1, 0] = int.Parse(button4.Text);
            inicio[1, 1] = int.Parse(button5.Text);
            inicio[1, 2] = int.Parse(button6.Text);
            inicio[2, 0] = int.Parse(button7.Text);
            inicio[2, 1] = int.Parse(button8.Text);
            inicio[2, 2] = int.Parse(button9.Text);
        }

        private void imprimirDatos(int[,] estado)
        {
            button1.Text = estado[0, 0].ToString();
            if (button1.Text == "0")
                button1.Visible = false;
            else
                button1.Visible = true;
            button2.Text = estado[0, 1].ToString();
            if (button2.Text == "0")
                button2.Visible = false;
            else
                button2.Visible = true;
            button3.Text = estado[0, 2].ToString();
            if (button3.Text == "0")
                button3.Visible = false;
            else
                button3.Visible = true;
            button4.Text = estado[1, 0].ToString();
            if (button4.Text == "0")
                button4.Visible = false;
            else
                button4.Visible = true;
            button5.Text = estado[1, 1].ToString();
            if (button5.Text == "0")
                button5.Visible = false;
            else
                button5.Visible = true;
            button6.Text = estado[1, 2].ToString();
            if (button6.Text == "0")
                button6.Visible = false;
            else
                button6.Visible = true;
            button7.Text = estado[2, 0].ToString();
            if (button7.Text == "0")
                button7.Visible = false;
            else
                button7.Visible = true;
            button8.Text = estado[2, 1].ToString();
            if (button8.Text == "0")
                button8.Visible = false;
            else
                button8.Visible = true;
            button9.Text = estado[2, 2].ToString();
            if (button9.Text == "0")
                button9.Visible = false;
            else
                button9.Visible = true;
        }

        private void swapValue(Button buttonA, Button buttonB)
        {
            string aux = buttonA.Text;
            buttonA.Text = buttonB.Text;
            buttonA.Visible = false;
            buttonB.Text = aux;
            buttonB.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button2.Text == "0")
            {
                swapValue(button1, button2);
            }
            else if(button4.Text == "0")
            {
                swapValue(button1, button4);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Text == "0")
            {
                swapValue(button2, button1);
            }
            else if (button3.Text == "0")
            {
                swapValue(button2, button3);
            }
            else if (button5.Text == "0")
            {
                swapValue(button2, button5);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button2.Text == "0")
            {
                swapValue(button3, button2);
            }
            else if (button6.Text == "0")
            {
                swapValue(button3, button6);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button1.Text == "0")
            {
                swapValue(button4, button1);
            }
            else if (button5.Text == "0")
            {
                swapValue(button4, button5);
            }
            else if (button7.Text == "0")
            {
                swapValue(button4, button7);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button2.Text == "0")
            {
                swapValue(button5, button2);
            }
            else if (button4.Text == "0")
            {
                swapValue(button5, button4);
            }
            else if (button6.Text == "0")
            {
                swapValue(button5, button6);
            }
            else if (button8.Text == "0")
            {
                swapValue(button5, button8);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button3.Text == "0")
            {
                swapValue(button6, button3);
            }
            else if (button5.Text == "0")
            {
                swapValue(button6, button5);
            }
            else if (button9.Text == "0")
            {
                swapValue(button6, button9);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button4.Text == "0")
            {
                swapValue(button7, button4);
            }
            else if (button8.Text == "0")
            {
                swapValue(button7, button8);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button5.Text == "0")
            {
                swapValue(button8, button5);
            }
            else if (button7.Text == "0")
            {
                swapValue(button8, button7);
            }
            else if (button9.Text == "0")
            {
                swapValue(button8, button9);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button6.Text == "0")
            {
                swapValue(button9, button6);
            }
            else if (button8.Text == "0")
            {
                swapValue(button9, button8);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            obtenerDatos();
            nodoInicio.setEstado(inicio);
            nodoSolucion = puzzle.getSolucion(nodoInicio, solucion);
            getStackSolucion(nodoSolucion);
            Console.WriteLine("Esta es la solucion");
            Console.WriteLine("------------------------------");
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            // Run this procedure in an appropriate event.  
            timer1.Interval = 1000;
            timer1.Enabled = true;
            // Hook up timer's tick event handler.  
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (stackSolucion.Count == 0)
            {
                // Exit loop code.  
                timer1.Enabled = false;
            }
            else
            {
                Nodo nodo = stackSolucion.Pop();
                imprimirDatos(nodo.getEstado());
                puzzle.imprimirEstado(nodo.getEstado());
                Console.WriteLine("****************");
            }
        }
    }
}
