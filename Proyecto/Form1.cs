using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoToresDeHanoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fondo = xinicial + 5 * altura;
            areaDibujo1 = pictureBox1.CreateGraphics();
            areaDibujo2 = pictureBox2.CreateGraphics();
            areaDibujo3 = pictureBox3.CreateGraphics();
            disco1 = new Disco(ancho, altura, xinicial, yinicial, Color.Red);
            disco2 = new Disco(ancho + inc, altura, xinicial - inc / 2, yinicial + altura, Color.Orange);
            disco3 = new Disco(ancho + 2 * inc, altura, xinicial - inc * 2 / 2, yinicial + altura * 2, Color.Yellow);
            disco4 = new Disco(ancho + 3 * inc, altura, xinicial - inc * 3 / 2, yinicial + altura * 3, Color.Green);
            disco5 = new Disco(ancho + 4 * inc, altura, xinicial - inc * 4 / 2, yinicial + altura * 4, Color.Blue);
        }

        Stack<Disco> torreA = new Stack<Disco>();
        Stack<Disco> torreB = new Stack<Disco>();
        Stack<Disco> torreC = new Stack<Disco>();

        Graphics areaDibujo1, areaDibujo2, areaDibujo3;
        Disco disco1,disco2,disco3,disco4,disco5,discotomado,discotop;
        int ancho = 100;
        int altura = 20;
        int anchotubo = 30;
        int xinicial = 60;
        int yinicial = 20;
        int fondo;
        int inc = 25;
        int movs = 0;
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtmovs.Visible = true;
            label2.Visible = true;
            textinfo.Visible = true;
            txtmovs.Text = "0";
            NuevoJuego();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (discotomado == null)
            {
                discotomado = torreA.Pop();
                DibujarTorre(torreA,areaDibujo1);
                movs++;
                txtmovs.Text = Convert.ToString(movs);
                textinfo.Text = "Selecione la torre a colocar el disco";
            }
            else
            {
                if (torreA.Count != 0)
                {
                    discotop = torreA.Peek();
                    if (discotop.Ancho < discotomado.Ancho)
                    {
                        MessageBox.Show("El disco no se pude apilar sobre uno más pequeño", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }                
                textinfo.Text = "Seleccione una torre para tomar un disco";
                discotomado.Y = fondo - (torreA.Count + 3) * altura;
                torreA.Push(discotomado);
                discotomado = null;
                DibujarTorre(torreA,areaDibujo1);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
             if (discotomado == null)
            {
                if (torreB.Count!=0)
                {
                    discotomado = torreB.Pop();
                    DibujarTorre(torreB, areaDibujo2);
                    movs++;
                    txtmovs.Text = Convert.ToString(movs);
                    textinfo.Text = "Selecione la torre a colocar el disco";
                }
                else
                {
                    MessageBox.Show("La torre está vacía, seleccione alguna otra");
                }       
            }
            else
            {
                if (torreB.Count != 0)
                {
                    discotop = torreB.Peek();
                    if (discotop.Ancho < discotomado.Ancho)
                    {
                        MessageBox.Show("El disco no se pude apilar sobre uno más pequeño", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                textinfo.Text = "Seleccione una torre para tomar un disco";
                discotomado.Y = fondo - (torreB.Count + 3) * altura;
                torreB.Push(discotomado);
                discotomado = null;
                DibujarTorre(torreB, areaDibujo2);
            }
            if (torreB.Count == 5)
            {
                MessageBox.Show("Felicidades, completaste la torre");
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (discotomado == null)
            {
                if (torreC.Count !=0)
                {
                    discotomado = torreC.Pop();
                    DibujarTorre(torreC, areaDibujo3);
                    movs++;
                    txtmovs.Text = Convert.ToString(movs);
                    textinfo.Text = "Selecione la torre a colocar el disco";
                }
                else
                {
                    MessageBox.Show("La torre está vacía, seleccione alguna otra");
                }
            }
            else
            {
                if (torreC.Count != 0)
                {
                    discotop = torreC.Peek();
                    if (discotop.Ancho < discotomado.Ancho)
                    {
                        MessageBox.Show("El disco no se pude apilar sobre uno más pequeño", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                textinfo.Text = "Seleccione una torre para tomar un disco";
                discotomado.Y = fondo - (torreC.Count + 3) * altura;
                torreC.Push(discotomado);
                discotomado = null;
                DibujarTorre(torreC, areaDibujo3);
            }
            if (torreC.Count==5)
            {
                MessageBox.Show("Felicidades, completaste la torre");
            }
        }
        void DibujarTorre(Stack<Disco> torre,Graphics areaDibujo)
        {
            areaDibujo.Clear(Color.DarkGray);
            SolidBrush brocha = new SolidBrush(Color.BurlyWood);
            Rectangle palo = new Rectangle(xinicial + ancho / 2 - anchotubo / 2, 0, anchotubo, 6 * altura);
            areaDibujo.FillRectangle(brocha, palo);

            Stack<Disco> torreAux = new Stack<Disco>();
            while (torre.Count != 0) 
            {
                Disco disco = torre.Pop();
                disco.Dibujar(areaDibujo);
                torreAux.Push(disco);
            }
            while (torreAux.Count != 0)
            {
                torre.Push(torreAux.Pop());
            }
        }
        public void NuevoJuego()
        {
            torreA.Clear();
            torreB.Clear();
            torreC.Clear();
            movs = 0;
            torreA.Push(disco5);
            torreA.Push(disco4);
            torreA.Push(disco3);
            torreA.Push(disco2);
            torreA.Push(disco1);
            DibujarTorre(torreA, areaDibujo1);
            DibujarTorre(torreB, areaDibujo2);
            DibujarTorre(torreC, areaDibujo3);
        }

    }
}
