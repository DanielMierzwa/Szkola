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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override double GetPerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
