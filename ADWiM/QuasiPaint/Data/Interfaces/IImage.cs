namespace OopPaint.Data.Interfaces
{
    /// <summary>
    /// Describes how a figure should be drawn on screen.
    /// </summary>
    public interface IImage
    {
        Color FillingColor { get; set; }
        Color BorderColor { get; set; }
        void DrawOnCanvas(Graphics g);
    }
}
