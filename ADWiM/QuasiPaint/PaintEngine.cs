using System.Drawing.Drawing2D;

using OopPaint.Data;
using OopPaint.Data.Enums;
using OopPaint.Data.Geometry;
using OopPaint.Data.Interfaces;
using OopPaint.Forms;
using Rectangle = OopPaint.Data.Geometry.Rectangle;

namespace OopPaint.Services
{
    public partial class PaintEngine
    {
        private readonly Panel _canvas;
        private readonly TextControls _textControls;
        private readonly Random _random = new();

        private FigureToDrawBase _selectedFigure;

        public PaintEngine(Panel canvas, TextControls textControls)
        {
            //Obsługa canvasu
            _canvas = canvas;
            _canvas.Paint += PaintCanvas;
            _canvas.MouseClick += CanvasClicked;

            //Domyślne ustawienia
            FigureSettings = new FigureSettings
            {
                SquareEdgeLength = 60,
                TriangleHeight = 70,
                TriangleBaseWidth = 80,
                CircleRadius = 40,
                RectangleHeight = 50,
                RectangleWidth = 80,

                CurrentBackgroundColor = Color.White,
                CurrentBorderColor = Color.Red,
                CurrentTextColor = Color.Red
            };

            //Pola tekstowe
            _textControls = textControls;
        }

        #region Settings

        public FigureSettings FigureSettings { get; private set; }

        public void UpdateFigureSettings(FigureSettings newSettings)
        {
            //todo: Zaktualizuj ustawienia figur
        }

        public void UpdateCurrentColors(FigureColorTarget target, Color color)
        {
            //todo: Zaktualizuj kolor w ustawieniach figur
            //tip: Pamiętaj, że FigureSettings jest niemutowalny (immutable) - zasady kopiowania rekordów
            //tip2: Jako argument dostajemy typ wyliczeniowy, użyj instrukcji switch
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Tej listy nie zmieniaj 😉
        /// </summary>
        private readonly List<FigureToDrawBase> _figures = new();

        public void AddFigure(FigureType figureType)
        {
            switch (figureType)
            {
                case FigureType.Square:
                    AddSquare();
                    break;

                case FigureType.Rectangle:
                    AddRectangle();
                    break;

                case FigureType.Circle:
                    AddCircle();
                    break;

                case FigureType.Triangle:
                    AddTriangle();
                    break;
            }
        }

        private void AddSquare()
        {
            //todo: Utwórz i dodaj kwadrat

            var square = new Square(FigureSettings.SquareEdgeLength) 
            { 
                Location=GetRandomPoint(FigureSettings.SquareEdgeLength,FigureSettings.SquareEdgeLength),
                FillingColor=FigureSettings.CurrentBackgroundColor,
                BorderColor=FigureSettings.CurrentBorderColor,
                TextColor=FigureSettings.CurrentTextColor
            };
            AddFigure(square);
        }

        private void AddRectangle()
        {
            //todo: Utwórz i dodaj prostokąt

            var rectangle = new Rectangle(FigureSettings.RectangleWidth,FigureSettings.RectangleHeight)
            {
                Location = GetRandomPoint(FigureSettings.RectangleWidth, FigureSettings.RectangleHeight),
                FillingColor = FigureSettings.CurrentBackgroundColor,
                BorderColor = FigureSettings.CurrentBorderColor,
                TextColor = FigureSettings.CurrentTextColor
            };
            AddFigure(rectangle);
        }

        private void AddCircle()
        {
            //todo: Utwórz i dodaj koło

            var circle = new Circle(FigureSettings.CircleRadius)
            {
                Location = GetRandomPoint(FigureSettings.CircleRadius, FigureSettings.CircleRadius),
                FillingColor = FigureSettings.CurrentBackgroundColor,
                BorderColor = FigureSettings.CurrentBorderColor,
                TextColor = FigureSettings.CurrentTextColor
            };

            AddFigure(circle);
        }

        private void AddTriangle()
        {
            //todo: Utwórz i dodaj trójkąt

            var triangle = new Triangle(FigureSettings.TriangleBaseWidth, FigureSettings.TriangleHeight)
            {
                Location = GetRandomPoint(FigureSettings.TriangleBaseWidth, FigureSettings.TriangleHeight),
                FillingColor = FigureSettings.CurrentBackgroundColor,
                BorderColor = FigureSettings.CurrentBorderColor,
                TextColor = FigureSettings.CurrentTextColor
            };
            AddFigure(triangle);
        }

        /// <summary>
        /// Dodaje nową figurę do listy i odświeża canvas.
        /// </summary>
        /// <param name="figure">Figura do dodania</param>
        private void AddFigure(FigureToDrawBase figure)
        {
            //W tej metodzie nie musisz nie zmieniać 😉
            _figures.Add(figure);
            InvalidateCanvas();
        }

        #endregion

        #region Text info

        /// <summary>
        /// Ustawia tekst z polem powierzchni figury.
        /// </summary>
        /// <param name="figure"></param>
        private void SetInfo(IFigure figure)
        {
            //todo: Ustaw pole powierzchni figury (u² to skrót od "jednostka (unit) do kwadratu")
            _textControls.AreaLabel.Text = $"{String.Empty} u²";

            //todo: Ustaw obwód figury (u to skrót od "jednostka (unit)")
            _textControls.PerimeterLabel.Text = $"{String.Empty} u";

            //todo: Ustaw nazwę klasy figury
            _textControls.ClassLabel.Text = String.Empty;

            if (figure is IDescribable drawFig)
            {
                //todo: Ustaw opis figury w polu StatementBox (dostępne w zmiennej drawFig)
                _textControls.StatementBox.Text = String.Empty;
            }

            else
            {
                _textControls.StatementBox.Text = "Brak opisu dla tej figury.";
            }
        }

        private void ClearInfo()
        {
            _textControls.AreaLabel.Text = String.Empty;
            _textControls.PerimeterLabel.Text = String.Empty;
            _textControls.ClassLabel.Text = String.Empty;
            _textControls.StatementBox.Text = "Kliknij na figurę, żeby sprawdzić";
        }

        #endregion

        #region Liczby losowe (to jest już gotowe, nie musisz zmieniać tego kodu)

        private PointF GetRandomPoint(float width, float height)
        {
            var availableWidth = Math.Max(1f, _canvas.Width - width - 20f);
            var availableHeight = Math.Max(1f, _canvas.Height - height - 20f);

            var x = 10f + (float)_random.NextDouble() * availableWidth;
            var y = 10f + (float)_random.NextDouble() * availableHeight;

            return new PointF(x, y);
        }

        #endregion

        #region Zarządzanie canvasem (już zaimplementowane)

        private void PaintCanvas(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            foreach (var figure in _figures)
            {
                figure.DrawOnCanvas(e.Graphics);

                if (figure == _selectedFigure)
                {
                    using var pen = new Pen(Color.DarkOrange, 2) { DashStyle = DashStyle.Dash };
                    var markerRect = new RectangleF(figure.Location.X - 6, figure.Location.Y - 6, 12, 12);
                    e.Graphics.DrawRectangle(pen, markerRect.X, markerRect.Y, markerRect.Width, markerRect.Height);
                }
            }
        }

        private void CanvasClicked(object? sender, MouseEventArgs e)
        {
            var clickPoint = e.Location;
            _selectedFigure = null;

            for (int i = _figures.Count - 1; i >= 0; i--)
            {
                if (_figures[i].ContainsPoint(clickPoint))
                {
                    _selectedFigure = _figures[i];
                    break;
                }
            }

            if (_selectedFigure != null)
            {
                if (e.Button == MouseButtons.Right && _selectedFigure is IRightClickable rightClickable)
                {
                    rightClickable.RightClickAction();
                }

                else
                {
                    SetInfo(_selectedFigure);
                }
            }

            else
            {
                ClearInfo();
            }

            InvalidateCanvas();
        }

        private void InvalidateCanvas()
        {
            _canvas.Invalidate();
        }

        #endregion
    }
}
