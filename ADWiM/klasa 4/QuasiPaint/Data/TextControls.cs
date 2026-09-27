namespace OopPaint.Data
{
    public sealed record TextControls
    {
        public required Label AreaLabel { get; init; }

        public required Label PerimeterLabel { get; init; }

        public required Label ClassLabel { get; init; }

        public required Label StatementBox { get; init; }
    }
}
