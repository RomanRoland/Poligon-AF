using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonCentrudeGreutate
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        Poligon test;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            test = new Poligon(@"../../TextFile1.txt");
            test.Draw(graphics, Color.Black);
            PointF G = test.G();
            while (test.Area() >= 1)
            {
                Poligon Sp = test.S();
                Sp.Draw(graphics, Color.Red);
                test = Sp;
            }
            PointF E = test.G();
            graphics.DrawEllipse(Pens.Black, G.X, G.Y, 1, 1);
            graphics.DrawEllipse(Pens.Blue, E.X, E.Y, 1, 1);
            label1.Text = $"{Engine.Distance(E, G)}";
            pictureBox1.Image = bitmap;

        }
    }
}
