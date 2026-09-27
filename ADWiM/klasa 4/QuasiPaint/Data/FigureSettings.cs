namespace OopPaint.Data
{
    public record FigureSettings
    {
        //Rozmiary figur domyślnie używane w aplikacji.
        public required float SquareEdgeLength { get; init; }
        public required float TriangleHeight { get; init; }
        public required float TriangleBaseWidth { get; init; }
        public required float CircleRadius { get; init; }
        public required float RectangleHeight { get; init; }
        public required float RectangleWidth { get; init; }

        //Kolory figur domyślnie używane w aplikacji.
        public required Color CurrentBackgroundColor { get; init; }
        public required Color CurrentBorderColor { get; init; }
        public required Color CurrentTextColor { get; init; }
    }
}
