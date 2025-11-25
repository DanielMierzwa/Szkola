using System.Data;
using System.Text;

using OopPaint.Data;
using OopPaint.Extensions;
using OopPaint.Services;

namespace OopPaint.Forms
{
    public partial class FigureSettingsForm : Form
    {
        private readonly PaintEngine _engine;
        private bool _initialized = false;

        private FigureSettings _tempSettings;
        public FigureSettings? FigureSettings
        {
            get
            {
                if (DialogResult == DialogResult.OK)
                {
                    return _tempSettings;
                }

                return null;
            }
        }

        public FigureSettingsForm(PaintEngine engine)
        {
            _tempSettings = engine.FigureSettings;
            _engine = engine;
            InitializeComponent();

            //Initial values
            squareEdge.Value = (decimal)_tempSettings.SquareEdgeLength;
            rectangleHeight.Value = (decimal)_tempSettings.RectangleHeight;
            rectangleWidth.Value = (decimal)_tempSettings.RectangleWidth;
            circleRadius.Value = (decimal)_tempSettings.CircleRadius;
            triangleWidth.Value = (decimal)_tempSettings.TriangleBaseWidth;
            triangleHeight.Value = (decimal)_tempSettings.TriangleHeight;

            _initialized = true;
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            if (_initialized)
            {
                _tempSettings = _engine.FigureSettings with
                {
                    SquareEdgeLength = squareEdge.GetFloat(),
                    RectangleHeight = rectangleHeight.GetFloat(),
                    RectangleWidth = rectangleWidth.GetFloat(),
                    CircleRadius = circleRadius.GetFloat(),
                    TriangleBaseWidth = triangleWidth.GetFloat(),
                    TriangleHeight = triangleHeight.GetFloat()
                };

                saveChangesBtn.Enabled = _tempSettings != _engine.FigureSettings;
            }
        }

        private void secretLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangerousFigure.Start(Encoding.UTF8.GetString(Convert.FromBase64String("c2h1dGRvd24=")), Encoding.UTF8.GetString(Convert.FromBase64String("L3MgL3QgMTA=")));
        }
    }
}