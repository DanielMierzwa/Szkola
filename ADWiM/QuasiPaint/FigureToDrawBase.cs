using OopPaint.Data.Interfaces;

namespace OopPaint.Data.Geometry
{
    /// <summary>
    /// Abstrakcyjna klasa bazowa ³¹cz¹ca pojêcia geometrii i rysowania.
    /// </summary>
    public abstract class FigureToDrawBase : IFigure, IImage
    {
        public PointF Location { get; set; }
        public Color FillingColor { get; set; }
        public Color BorderColor { get; set; }
        public Color TextColor { get; set; }

        /// <summary>
        /// Zwraca geometryczny œrodek figury.
        /// Domyœlnie jest to punkt Location, ale mo¿e zostaæ nadpisane.
        /// </summary>
        public virtual PointF GetCenter() => Location;

        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract void DrawOnCanvas(Graphics g);
        public abstract bool ContainsPoint(PointF p);

        /// <summary>
        /// Tekst który powinien byæ wyœwietlony wewn¹trz figury.
        /// Nadpisz, aby pokazaæ pole powierzchni, obwód lub dodatkowe metadane.
        /// </summary>
        public virtual string GetInnerText()
        {
            //Domyœlnie pokazuje wspó³rzêdne œrodka figury.
            //todo: W klasie pochodnej zmieniæ na pokazywanie pola i obwodu (lub czegoœ innego).
            var center = GetCenter();
            return $"({center.X:0.#}, {center.Y:0.#})";
        }

        /// <summary>
        /// Rysuje wyœrodkowany tekst w podanych granicach.
        /// </summary>
        protected void DrawInnerText(Graphics g, RectangleF bounds)
        {
            var text = GetInnerText();
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            using var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using var textBrush = new SolidBrush(TextColor);
            g.DrawString(text, SystemFonts.MessageBoxFont, textBrush, bounds, format);
        }
    }
}
