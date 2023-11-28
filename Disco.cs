using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProyectoToresDeHanoi
{
    class Disco
    {
        int posisionx, posisiony,ancho,alto;
        Color discoColor;

        public int Y
        {
            get { return posisiony; }
            set { posisiony = value; }
        }

        public int Ancho
        {
            get { return ancho; }
        }

        public Disco(int anchoval, int altoval,int xinicial,int yinicial,Color colore)
        {
            ancho = anchoval;
            alto = altoval;
            posisionx = xinicial;
            posisiony = yinicial;
            discoColor = colore;
        }
        
        public void Dibujar(Graphics papel)
        {
            SolidBrush lapiz = new SolidBrush(discoColor);
            papel.FillEllipse(lapiz, posisionx, posisiony, ancho, alto);
        }
    }
}
