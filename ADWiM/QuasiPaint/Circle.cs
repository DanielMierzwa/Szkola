using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPaint.Data.Geometry
{
    internal class Circle : FigureToDrawBase
    {
        public Circle(float Radiuse)
        {
            Radius = Radiuse;
        }
        public float Radius { get; }
        public override bool ContainsPoint(PointF p)
        {
            throw new NotImplementedException();
        }

        public override void DrawOnCanvas(Graphics g)
        {
            using (var brush = new SolidBrush(FillingColor))
            {
                using (var pen = new Pen(BorderColor, 2))
                {
                    var center = GetCenter();

                    //Wskazówka: klasa powinna zawierać właściwość "Radius"
                    var rect = new RectangleF(center.X - Radius, center.Y - Radius, Radius * 2, Radius * 2);

                    g.FillEllipse(brush, rect);
                    g.DrawEllipse(pen, rect);

                    DrawInnerText(g, rect);
                }
            }
        }

        public override double GetArea()
        {
            throw new NotImplementedException();
        }

        public override double GetPerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
