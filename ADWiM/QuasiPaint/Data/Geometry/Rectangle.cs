using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPaint.Data.Geometry
{
    internal class Rectangle : FigureToDrawBase
    {
        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Width { get; }
        public float Height { get; }
        public override bool ContainsPoint(PointF p)
        {
            if (p.X < Location.X && p.X > Location.X + Width)
                return false;
            if (p.Y < Location.Y && p.Y > Location.Y + Height)
                return false;
            return true;
        }

        public override void DrawOnCanvas(Graphics g)
        {
            using (var brush = new SolidBrush(FillingColor))
            {
                using (var pen = new Pen(BorderColor, 2))
                {
                    var rect = new RectangleF(Location.X, Location.Y, Width, Height);

                    g.FillRectangle(brush, rect);
                    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);

                    DrawInnerText(g, rect);
                }
            }
        }

        public override double GetArea()
        {
            return (double)Width*Height;
        }

        public override double GetPerimeter()
        {
            return (double)(2 * Width + 2 * Height);
        }


        public override string GetInnerText()
        {
            return $"({GetArea()}u², {GetPerimeter()}u)";
        }

        public override string GetDescription()
        {
            return "Kwadrat ma 4 kąty proste i 2 pary równych boków";
        }
    }
}
