using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace FF.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private float rangeLeft = -20;
    [ObservableProperty]
    private float rangeRight = 20;

    [ObservableProperty]
    string name;
    [ObservableProperty]
    float delta;

    [ObservableProperty]
    float zoom=1f;

    [ObservableProperty]
    public ObservableCollection<ISeries> series;

    [ObservableProperty]
    float a = 1;
    [ObservableProperty]
    float b = 0;
    [ObservableProperty]
    float c = 0;

    #region sensors
    partial void OnAChanged(float value) => Generate();
    partial void OnCChanged(float value) => Generate();
    partial void OnBChanged(float value) => Generate();
    partial void OnRangeLeftChanged(float value) => Generate();
    partial void OnRangeRightChanged(float value) => Generate();
    #endregion

    #region axes
    public Axis[] XAxes { get; set; }
    = new Axis[]
    {
                new Axis
                {
                    Name = "0X",
                    NamePaint = new SolidColorPaint(SKColors.LightPink),

                    LabelsPaint = new SolidColorPaint(SKColors.Pink),
                    TextSize = 20,

                    SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 2 },
                    MinStep=1
                }
    };

    public Axis[] YAxes { get; set; }
        = new Axis[]
        {
                new Axis
                {
                    Name = "OY",
                    NamePaint = new SolidColorPaint(SKColors.LightPink),

                    LabelsPaint = new SolidColorPaint(SKColors.Pink),
                    TextSize = 20,

                    SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                    {
                        StrokeThickness = 2,
                        PathEffect = new DashEffect(new float[] { 3, 3 })
                    },
                    MinStep=1
                }
        };
    #endregion

    public MainViewModel()
    {
        Generate();
    }
    public void Generate()
    {
        var quadraticPoints = new ObservableCollection<ObservablePoint>();
        var linearPoints = new ObservableCollection<ObservablePoint>();

        // y = x² - 2x - 3
        for (double x = rangeLeft; x <= rangeRight; x += 0.1)
        {
            quadraticPoints.Add(
                new ObservablePoint(
                    x,
                    A * x * x + B * x + C
                )
            );
        }

        // y = 2x + 1
        for (double x = rangeLeft; x <= rangeRight; x += 0.1)
        {
            linearPoints.Add(
                new ObservablePoint(
                    x,
                    A*2 * x + B
                )
            );
        }
        Delta = B*B-(4*A*C);
        float x1 = (-(float)Math.Sqrt(Delta) - B) /( 2 * A);
        float x2 = ((float)Math.Sqrt(Delta) - B) /( 2 * A);
        Series =
        [
            new LineSeries<ObservablePoint>
            {
                Name="0X",
                Stroke = new SolidColorPaint(SKColors.MediumPurple) { StrokeThickness = 2 },
                Values = new ObservableCollection<ObservablePoint>
                {   
                    new ObservablePoint(rangeLeft-200,0),
                    new ObservablePoint(rangeRight+200, 0) 
                },
                
            },
            new LineSeries<ObservablePoint>
            {
                Name="0Y",
                Stroke = new SolidColorPaint(SKColors.MediumPurple) { StrokeThickness = 2 },
                Values = new ObservableCollection<ObservablePoint>
                {
                    new ObservablePoint(0.0000001,10000),
                    new ObservablePoint(0, 10000)
                },

            },
            new LineSeries<ObservablePoint>
            {
                Name = "{ y = "+GetQuadraticalFunctionName()+" }",
                Values = quadraticPoints,
                GeometrySize = 0
            },

            new LineSeries<ObservablePoint>
            {
                Name = "{ y = "+GetDerativeFunctionName()+" }",
                Values = linearPoints,
                GeometrySize = 0
            },

            new ScatterSeries<ObservablePoint>
            {
                Stroke = new SolidColorPaint(SKColors.Pink) { StrokeThickness = 2 },
                Fill = null,
                Values = new ObservableCollection<ObservablePoint>
                {
                    new ObservablePoint(x1, 0),
                    new ObservablePoint(x2, 0)
                }
            }
        ];
        Name = "f(x) = "+GetQuadraticalFunctionName();
    }
    public string GetQuadraticalFunctionName()
    {
        return $" {Format(A, "x²", true)}{Format(B, "x")}{Format(C, "")}";
    }

    public string GetDerativeFunctionName()
    {
        return $"{Format(2 * A, "x", true)}{Format(B, "")}";
    }
    public string Format(float value, string c)
    {
        if (value == 1)
            return "+"+c;
        if (value == -1)
            return c;
        if (value == 0)
            return "";
        if (value > 0)
            return $"+{value}" + c;
        return $"{value}" + c;

    }
    public string Format(float value, string c, bool x)
    {
        if (value == 1)
            return c;
        if (value > 0)
            return $"{value}" + c;
        return Format(value, c);

    }


}