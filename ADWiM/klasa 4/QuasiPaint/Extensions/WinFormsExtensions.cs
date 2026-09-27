namespace OopPaint.Extensions
{
    public static class WinFormsExtensions
    {
        public static float GetFloat(this NumericUpDown numeric)
            => Convert.ToSingle(numeric.Value);
    }
}
