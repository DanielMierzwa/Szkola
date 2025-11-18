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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override double GetPerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
