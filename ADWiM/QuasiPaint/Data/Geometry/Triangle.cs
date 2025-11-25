using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPaint.Data.Geometry
{
    internal class Triangle: FigureToDrawBase
    {

        public Triangle(float width, float height)
        {
            Width=width;
            Height = height;
        }

        public float Width { get; }
        public float Height { get; }
        public override bool ContainsPoint(PointF p)
        {
            // Wierzchołki
            var p1 = _p1;
            var p2 = _p2;
            var p3 = _p3;

            // Funkcja pomocnicza – znak pola równoległoboku
            float Sign(PointF a, PointF b, PointF c)
            {
                return (a.X - c.X) * (b.Y - c.Y) - (b.X - c.X) * (a.Y - c.Y);
            }

            // Obliczamy znaki orientacji
            float d1 = Sign(p, p1, p2);
            float d2 = Sign(p, p2, p3);
            float d3 = Sign(p, p3, p1);

            bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            // Punkt jest w środku jeśli nie ma jednocześnie znaków dodatnich i ujemnych
            return !(hasNeg && hasPos);
        }

        private PointF _p1 => Location;
        private PointF _p2 => new(Location.X + Width, Location.Y);
        private PointF _p3 => new(Location.X, Location.Y + Height);

        public override void DrawOnCanvas(Graphics g)
        {
            using (var brush = new SolidBrush(FillingColor))
            {
                using (var pen = new Pen(BorderColor, 2))
                {
                    var points = new[] { _p1, _p2, _p3 };
                    g.FillPolygon(brush, points);
                    g.DrawPolygon(pen, points);

                    var bounds = RectangleF.FromLTRB(
                        Math.Min(Math.Min(_p1.X, _p2.X), _p3.X),
                        Math.Min(Math.Min(_p1.Y, _p2.Y), _p3.Y),
                        Math.Max(Math.Max(_p1.X, _p2.X), _p3.X),
                        Math.Max(Math.Max(_p1.Y, _p2.Y), _p3.Y));

                    DrawInnerText(g, bounds);
                }
            }
        }

        public override double GetArea()
        {
            return (double)Height * Width;
        }

        public override double GetPerimeter()
        {
            double x = Math.Sqrt((_p2.X - _p3.X) + (_p1.Y - _p3.Y));
            return (double)( x+Width+Height);
        }
        public override string GetInnerText()
        {
            return $"({GetArea()}u², {GetPerimeter()}u)";
        }

        public override string GetDescription()
        {
            return "Trójkąt to przecięty na pół równoległobok";
        }
    }
}
