using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonCentrudeGreutate
{
    public class Poligon
    {
        PointF[] points;
        public Poligon(string fileName)
        {
            TextReader reader = new StreamReader(fileName);
            string buffer;
            List<PointF> pointsF = new List<PointF>();
            while ((buffer = reader.ReadLine()) != null) 
            {
                string[] t = buffer.Split(' ');
                pointsF.Add(new PointF(float.Parse(t[0]), float.Parse(t[1])));
            }
            reader.Close();
            points = new PointF[pointsF.Count];
            for (int i = 0; i < pointsF.Count; i++) 
                points[i] = pointsF[i];
        }
        public void Draw(Graphics handler, Color color)
        {
            handler.DrawPolygon(new Pen(color), points);
        }
        public Poligon (Poligon poligon) 
        {
            points = new PointF[poligon.points.Length];
        }
        public Poligon S()
        {
            Poligon aux = new Poligon(this);
            for (int i = 0; i < points.Length - 1; i++)
                aux.points[i] = new PointF((points[i].X + points[i + 1].X) / 2,
                                           (points[i].Y + points[i + 1].Y) / 2);
            aux.points[points.Length - 1] = new PointF((points[points.Length - 1].X + points[0].X) / 2,
                                                       (points[points.Length - 1].Y + points[0].Y) / 2);
            return aux; 
        }

        public float Area()
        {
            float area = 0;
            for (int i = 0; i < points.Length - 1; i++)
                area += points[i].X * points[i + 1].Y - points[i + 1].X * points[i].Y;
            area += points[points.Length - 1].X
                    * points[0].Y
                    - points[0].X
                    * points[points.Length - 1].Y;
            return 0.5F * Math.Abs(area);
        }
        public PointF G()
        {
            float x = 0, y = 0;
            for (int i = 0; i < points.Length; i++)
            {
                x += points[i].X;
                y += points[i].Y;
            }
            return new PointF(x/points.Length, y/points.Length);
        }
    }
}
