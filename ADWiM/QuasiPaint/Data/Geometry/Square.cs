using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPaint.Data.Geometry
{
    public class Square : FigureToDrawBase
    {
        public Square(float size) 
        {
            this.Size = size;
        }
        public float Size {  get; }
        public override bool ContainsPoint(PointF p)
        {
            if (p.X < Location.X && p.X > Location.X + Size)
                return false;
            if (p.Y < Location.Y && p.Y > Location.Y + Size)
                return false;
            return true;

        }

        public override void DrawOnCanvas(Graphics g)
        {
            using (var brush = new SolidBrush(FillingColor))
            {
                using (var pen = new Pen(BorderColor, 2))
                {
                    var rect = new RectangleF(Location.X, Location.Y, Size, Size);

                    g.FillRectangle(brush, rect);
                    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);

                    DrawInnerText(g, rect);
                }
            }
        }

        public override double GetArea()
        {
            return (double)Size * Size;
        }

        public override double GetPerimeter()
        {
            return (double)(4 * Size);
        }
        public override string GetInnerText()
        {
            return $"({GetArea()}u², {GetPerimeter()}u)";
        }

        public override string GetDescription()
        {
            return "Kwadrat ma 4 takie same boki";
        }
    }
}
