using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FF.Models;

namespace FF.ViewModels
{
    public partial class QuadraticPlotDriver : ObservableObject
    {
        public ObservablePoint[] QuadraticPoints;
        ObservablePoint[] DerivativePoints;
        ObservablePoint[] Roots;
        Axis QuadraticXAxis;
        Axis QuadraticYAxis;

        public Axis[] XAxes, YAxes;
        public QuadraticPlotDriver(double resolution, double min, double max)
        {
            var pointsCount = (int)((max - min) / resolution) + 1;
            Roots = [new(), new()];
            QuadraticPoints = new ObservablePoint[pointsCount];
            DerivativePoints = new ObservablePoint[pointsCount];

            for (var i = 0; i < QuadraticPoints.Length; i++)
            {
                QuadraticPoints[i] = new(i * resolution + min, null);
                DerivativePoints[i] = new(i * resolution + min, null);
            }

            // Inicjalizacja osi X i Y dla wykresu funkcji kwadratowej
            QuadraticXAxis = new Axis()
            {
                MaxLimit = 10,
                MinLimit = -10,
                MinStep = 1,
                Name = "Y",
                NamePaint = new SolidColorPaint(SKColor.Parse("#000011")),
                SeparatorsPaint = new SolidColorPaint(SKColor.Parse("#C8C8C8"))
                {
                    StrokeThickness = 1,
                    PathEffect = new DashEffect(new float[] { 5, 5 })
                }
            };

            QuadraticYAxis = new Axis()
            {
                MaxLimit = 10,
                MinLimit = -10,
                MinStep = 1,
                Name = "X",
                NamePaint = new SolidColorPaint(SKColor.Parse("#001100")),
                SeparatorsPaint = new SolidColorPaint(SKColor.Parse("#C8C8C8"))
                {
                    StrokeThickness = 1,
                    PathEffect = new DashEffect(new float[] { 5, 5 })
                }
            };

            // Obsługa zoomu na wykresie
            QuadraticYAxis.PropertyChanged +=AXisPropertyChanged;
            QuadraticXAxis.PropertyChanged += AXisPropertyChanged;

            // [...]

            YAxes = [QuadraticYAxis];
            XAxes = [QuadraticXAxis];
        }


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TextScale))]
        [NotifyPropertyChangedFor(nameof(SliderScale))]
        [NotifyPropertyChangedFor(nameof(IsZoomingEnabled))]
        private int _scale;

        [ObservableProperty]
        private bool _isZoomingEnabled = true;

        public string TextScale
        {
            get => Scale.ToString();
            set
            {
                if (Int32.TryParse(value, out var numericValue))
                {
                    Scale = numericValue;
                }
            }
        }

        public double SliderScale
        {
            get => Scale;
            set => Scale = Convert.ToInt32(value);
        }

        partial void OnScaleChanged(int value)
        {
            XAxes[0].MaxLimit = value;
            XAxes[0].MinLimit = -value;

            YAxes[0].MaxLimit = value;
            YAxes[0].MinLimit = -value;
        }

        private void AXisPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Blokowanie skalowania
            if (e.PropertyName == nameof(Axis.MaxLimit) || e.PropertyName == nameof(Axis.MinLimit))
            {
                if ((XAxes[0].MinLimit != -Scale || XAxes[0].MaxLimit != Scale || YAxes[0].MinLimit != -Scale || YAxes[0].MaxLimit != Scale) && IsZoomingEnabled)
                {
                    IsZoomingEnabled = false;
                }
            }
        }

        [RelayCommand]
        private void ResetScale()
        {
            Scale = 10;
        }

        public void RecalculatePoints(int paramA, int paramB, int paramC, FunctionRoot[] roots)
        {
            foreach (var p in QuadraticPoints)
            {
                p.Y = FxCalculator.CalculateFx(5, 5, 5, p.X.Value);
            }

            // Tutaj obliczamy pochodną
            // [...]

            if (roots.Length > 0)
            {
                // Jeżeli funkcja ma pierwiastki rzeczywiste lub zespolone, możemy obliczyć je tutaj
                // [...]
            }
        }
    }
}
